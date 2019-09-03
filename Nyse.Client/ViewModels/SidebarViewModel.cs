using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nyse.Client
{
    public class SidebarViewModel : BaseViewModel
    {
        #region Private fields
        // The value of the text inside the search box
        private string _searchText;

        // List of filtered stock symbols
        private ObservableCollection<SidebarListItemViewModel> _filteredStocks;

        #endregion

        #region Public Properties

        // Property for the List of Sidebar view models
        public ObservableCollection<SidebarListItemViewModel> SidebarItems { get; set; }

        //Property for the Stocks list
        public ObservableCollection<Stock> Stocks { get; set; }

        // Property for the filtered stocks list
        public ObservableCollection<SidebarListItemViewModel> FilteredStocks
        {
            get => _filteredStocks;
            set
            {
                _filteredStocks = value;
                OnPropertyChanged("FilteredStocks");
            }
        }

        // The value of the search text box property
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
            }
        }

        public bool FetchDataOnConstruction { get; set; } = false;

        public IStockReader DataReader { get; set; }


        #endregion

        #region Commands

        public ICommand SearchStocksCommand { get; set; }

        public ICommand ShowSettingsCommand { get; set; }

        #endregion

        #region Constructor

        public SidebarViewModel(IStockReader dataReader)
        {
            // Instantiates the datareader
            DataReader = dataReader;

            // Gets the data from the web server and populates the stocks and filtered stocks
            onStart();

            //creates the command to filter stocks
            SearchStocksCommand = new RelayCommand(() => FilterStockSymbols(SearchText));

            // Creates command to show the settings window
            ShowSettingsCommand = new RelayCommand(() => ShowSettings());
        }

        #endregion

        #region Controls

        // Event that fires when this class is constructed
        public async void onStart()
        {
            // Show that the data has been fetched on construction
            FetchDataOnConstruction = true;

            // Sets the Stocks with the data from the web server
            Stocks = await DataReader.GetStocks();

            if (Stocks == null) return;

            await Task.Run(() =>
            {
                // Instantiates empty collection of FilteredStocks
                SidebarItems = new ObservableCollection<SidebarListItemViewModel>();

                //Populates the collection of FilteredStocks with sidebar viewmodels
                foreach (var stock in Stocks)
                {
                    SidebarItems.Add(new SidebarListItemViewModel(stock));
                };

                FilteredStocks = SidebarItems;
            });
        }

        // Searches all the stocks symbols and filters by the SearchText property
        public async void FilterStockSymbols(string SearchText)
        {
            // I put this here so the unit test would would be async, but im not really sure if u should wrap
            // the whole function in a task or not?
            await Task.Run(() =>
            {
                // Checks for null
                if (SidebarItems == null) return;

                // Check to see if search box is null or empty
                if (string.IsNullOrEmpty(SearchText))
                {
                    FilteredStocks = new ObservableCollection<SidebarListItemViewModel>(SidebarItems);
                    return;
                }

                // Find all stocks symbols that contain the search text
                FilteredStocks = new ObservableCollection<SidebarListItemViewModel>(SidebarItems.Where(s => s.stockSymbol.ToLower().Contains(SearchText)));

            });
        }

        // Sets the current window to the settings window
        public async void ShowSettings()
        {
            Console.WriteLine("show settings window");

            var vm = Ioc.Kernel.Get<WindowViewModel>();

            // Handles the view changed events
            vm.ViewModelChanged();

            await Task.Run(() =>
            {
                vm.CurrentViewModel = new SettingsViewModel();
            });
        }

        #endregion
    }
}
