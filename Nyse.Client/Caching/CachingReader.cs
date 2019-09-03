using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    public class CachingReader : IStockReader
    {
        #region Private Members

        private IStockReader _WrappedReader;

        private Dictionary<string, ObservableCollection<Stock>> _CachedItems;

        #endregion

        #region Public Properties

        public bool StockDataCached { get; set; } = false;

        #endregion

        #region Constructor

        public CachingReader(IStockReader wrapperReader)
        {
            _WrappedReader = wrapperReader;
        }

        #endregion

        #region Controls

        // Retrieves the selected Stocks data from the Web Api or gets it from the cache
        public async Task<ObservableCollection<Stock>> GetStockData(string symbol)
        {
            // If the cache is populated Get the data from the cache
            if (StockDataCached == true)
            {
                var StockData = _CachedItems.FirstOrDefault(s => s.Key == symbol);

                return StockData.Value;
            }
            // If the cache is empty get the data from the web api
            else
            {
                var data = await _WrappedReader.GetStockData(symbol);

                return data;
            }
        }

        // Returns a list of Stock symbols
        public async Task<ObservableCollection<Stock>> GetStocks()
        {
            // Gets the list of Stock Symbols
            var data = await _WrappedReader.GetStocks();

            // Creates a local cache of all of the stock data for all stock symbols
            // Takes all of the stock symbols as a parameter
            CreateLocalCache(data.Select(s => s.stockSymbol).ToList());

            return data;
        }

        // Method that creates a local cache of all of the stock data, for all stock symbols
        private async void CreateLocalCache(List<string> symbols)
        {
            _CachedItems = new Dictionary<string, ObservableCollection<Stock>>();

            //Iterates through all the stock symbol
            foreach (var s in symbols)
            {
                // Sets the _CachedItems to a key value pair of stockSymbols, Stock Data
                var data = await _WrappedReader.GetStockData(s);

                // delay so the http request fires smoothly
                await Task.Delay(1500);

                // Adds the stockSymbols, and the Stock Data to the _CachedItems dictionary
                _CachedItems.Add(s, data);
            }

            // Sets the Cached data to true so the data requests are retrieved from _CachedItems instead of the Injected Service
            StockDataCached = true;
        }

        #endregion
    }
}
