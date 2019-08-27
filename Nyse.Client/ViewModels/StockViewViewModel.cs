using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nyse.Client
{
    // View model for the Component that displayed the info for the selected stock
    public class StockViewViewModel : BaseViewModel
    {
        #region Private Members

        private ObservableCollection<Stock> _Stock;

        #endregion

        #region Public Properties

        public IStockReader dataReader { get; set; } 

        public ObservableCollection<Stock> Stock
        {
            get => _Stock;
            set
            {
                _Stock = value;
                OnPropertyChanged("Stock");
            }
        }

        #endregion

        #region Constructor

        public StockViewViewModel(string Symbol, IStockReader stockReader)
        {
            // Constructor injected Data Reader
            dataReader = stockReader;

            // Calls async task to populate the stock property with data
            OnStart(Symbol);
        }

        #endregion

        #region Controls

        // Called when this class is constructed
        public async void OnStart(string Symbol)
        {
            // Populates the selected stock data when the class is constructed 
            Stock = await dataReader.GetStockData(Symbol);
        }

        #endregion
    }
}
