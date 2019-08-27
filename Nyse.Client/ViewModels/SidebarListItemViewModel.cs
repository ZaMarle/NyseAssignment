using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nyse.Client
{
    public class SidebarListItemViewModel : BaseViewModel
    {
        #region Public Member

        public string stockSymbol { get; set; }

        #endregion

        #region Commands

        public RelayCommand StockSelectedCommand { get; set; }

        #endregion

        #region Constructor

        public SidebarListItemViewModel(Stock stock)
        {
            stockSymbol = stock.stockSymbol;
            StockSelectedCommand = new RelayCommand(() => StockSelected());
        }

        #endregion

        #region Methods 

        // Command that calls the Update Stock method on the Window View Model when you select a stock in the sidebar
        public void StockSelected()
        {
            // Gets the instance of WindowViewModel from the Ioc container
            var vm = Ioc.Kernel.Get<WindowViewModel>();

            // Updates the Stock from the stock selected
            vm.UpdateStock(stockSymbol);
        }

        #endregion  
    }
}
