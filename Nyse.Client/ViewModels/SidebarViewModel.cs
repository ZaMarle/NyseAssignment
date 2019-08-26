using Newtonsoft.Json;
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

        public IStockReader DataReader { get; set; }


        #endregion

        #region Commands

        public ICommand SearchStocksCommand { get; set; }

        #endregion

        #region Constructor

        public SidebarViewModel(IStockReader dataReader)
        {
            // Instantiates the datareader
            DataReader = dataReader;

            // Instantiates the stocks property 
            Stocks = new ObservableCollection<Stock>();

            // Gets the data from the web server and populates the stocks and filtered stocks
            onStart();

            //creates the command to filter stocks
            SearchStocksCommand = new RelayCommand(() => FilterStockSymbols(SearchText));
        }

        #endregion

        #region Controls

        // Event that fires when this class is constructed
        public async void onStart()
        {
            // Sets the Stocks with the data from the web server
            Stocks = await DataReader.GetStocks();

            if (Stocks == null) return;

            // Instantiates empty collection of SidebarItems
            SidebarItems = new ObservableCollection<SidebarListItemViewModel>();

            //Populates the collection of sidebarItems with sidebar viewmodels
            foreach (var stock in Stocks)
            {
                SidebarItems.Add(new SidebarListItemViewModel(stock));
            };

            // Instantiates the filtered stocks and sets the value to the SidebarItems value
            FilteredStocks = new ObservableCollection<SidebarListItemViewModel>(SidebarItems);
        }


        // Searches all the stocks symbols and filters by the SearchText property
        public void FilterStockSymbols(string SearchText)
        {
            if (FilteredStocks == null) return;

            // Check to see if search box is null or empty
            if (string.IsNullOrEmpty(SearchText))
            {
                FilteredStocks = new ObservableCollection<SidebarListItemViewModel>(SidebarItems);
                return;
            }

            // Find all stocks symbols that contain the search text
            FilteredStocks = new ObservableCollection<SidebarListItemViewModel>(SidebarItems.Where(s => s.stockSymbol.ToLower().Contains(SearchText)));

        }

        #endregion
    }
}
