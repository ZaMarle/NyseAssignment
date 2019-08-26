using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Nyse.Client
{
    public interface IStockReader
    {
        Task<ObservableCollection<Stock>> GetStockData(string symbol);
        Task<ObservableCollection<Stock>> GetStocks();
    }
}
