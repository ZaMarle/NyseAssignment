using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nyse.Client
{

    // TODO: Need to re create the interface to reaturn tasks, also maybe change ienumerable to bindable collection

    public class ApiStockReader : IStockReader
    {
        public HttpClient WebService { get; set; } = new HttpClient();

        // Retrieves the data for the selected stock
        public async Task<ObservableCollection<Stock>> GetStockData(string symbol)
        {
            using (HttpResponseMessage res = await WebService.GetAsync("https://localhost:44363/api/stocks/" + symbol))
            {
                if (res.IsSuccessStatusCode)
                {
                    try
                    {
                        var stocks = await res.Content.ReadAsAsync<ObservableCollection<Stock>>();

                        return stocks;
                    }
                    catch
                    {
                        Console.WriteLine("failed to retrieve stocks");
                        return null;
                    }

                }
                else
                {
                    Console.WriteLine("error loading stocks data from ApiStockReader");
                    return null;
                }
            }
        }

        // Retrieve the first one of all the stocks
        public async Task<ObservableCollection<Stock>> GetStocks()
        {
            using (HttpResponseMessage res = await WebService.GetAsync("https://localhost:44363/api/stocks"))
            {
                if (res.IsSuccessStatusCode)
                {
                    try
                    {
                        var stocks = await res.Content.ReadAsAsync<ObservableCollection<Stock>>();

                        return stocks;
                    }
                    catch
                    {
                        Console.WriteLine("failed to retrieve stocks");
                        return null;
                    }
                    
                }
                else
                {
                    Console.WriteLine("error loading stocks data from ApiStockReader");
                    return null;
                }
            }
        }
    }
}
