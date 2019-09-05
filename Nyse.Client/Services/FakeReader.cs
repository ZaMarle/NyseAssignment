using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    public class FakeReader : IStockReader
    {
         #region Test Data

        // Sets up the Test Data for use in this class
        ObservableCollection<Stock> testData = new ObservableCollection<Stock>()
        {
            new Stock()
            {
                stockSymbol = "abb",
                date = new DateTime(2000, 10, 1),
                stockPriceOpen = 10,
                stockPriceHigh = 11,
                stockPriceLow  = 9,
                stockPriceClose = 11,
                stockVolume = 132222,
                stockPriceAdjClose = 1
            },
            new Stock()
            {
                stockSymbol = "aab",
                date = new DateTime(2002, 10, 12),
                stockPriceOpen = 13,
                stockPriceHigh = 16,
                stockPriceLow  = 9,
                stockPriceClose = 15,
                stockVolume = 132226,
                stockPriceAdjClose = 3
            }
        };

        #endregion

        // Fake service call to retrieve data for a single stock
        public async Task<ObservableCollection<Stock>> GetStockData(string symbol)
        {
            var data = new ObservableCollection<Stock>();

            var stock = testData.Where(s => s.stockSymbol == symbol);

            await Task.Run(() =>
            {
                foreach (var s in stock)
                {
                    data.Add(s);
                }
            });

            return data;
        }

        // Fake service call to retrieve all of the stocks symbols
        public async Task<ObservableCollection<Stock>> GetStocks()
        {
            var data = new ObservableCollection<Stock>();

            await Task.Run(() =>
            {
                foreach (var stock in testData)
                {
                    data.Add(stock);
                }
            });

            return data;
        }
    }
}
