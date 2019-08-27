using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Nyse.Client
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        private StockViewViewModel _CurrentViewModel;

        readonly IStockReader stockReader = Ioc.Kernel.Get<IStockReader>();

        #endregion

        #region Public Properties

        public StockViewViewModel CurrentViewModel
        {
            get => _CurrentViewModel;
            set
            {
                _CurrentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public SidebarViewModel SidebarViewModel { get; set; }

        #endregion

        #region Constructor

        public WindowViewModel()
        {
            CurrentViewModel = new StockViewViewModel("abb", stockReader);
            SidebarViewModel = new SidebarViewModel(stockReader);
        }

        #endregion

        #region Methods

        // Sets the CurrentViewModel property to a new StockViewViewModel instance 
        public async void UpdateStock(string stockSymbol)
        {
            await Task.Run(() =>
            {
                CurrentViewModel = new StockViewViewModel(stockSymbol, stockReader);
            });
        }

        #endregion
    }
}
