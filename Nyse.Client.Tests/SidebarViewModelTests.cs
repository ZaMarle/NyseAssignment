using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nyse.Client.Tests
{
    [TestClass]
    public class SidebarViewModelTests
    {
        // Shows if the call was made to retrieve data when call is constructed
        [TestMethod]
        public void Call_For_Data_When_Constructed()
        {
            // Arrange
            var dataReader = new FakeReader();
            var viewModel = new SidebarViewModel(dataReader);

            // Assert
            Assert.AreEqual(true, viewModel.FetchDataOnConstruction);
        }
        
        // Tests sleeps for 1 second to allow time for the object to be constructed
        [TestMethod]
        public void SidebarViewModel_onStart_Gets_Stocks()
        {
            // Arrange
            IStockReader dataReader = new FakeReader();
            SidebarViewModel viewModel = new SidebarViewModel(dataReader);

            Thread.Sleep(1000);

            // Assert
            Assert.IsNotNull(viewModel.Stocks);
            Assert.AreEqual(2, viewModel.Stocks.Count);
        }

        // Tests sleeps for 1 second to allow time for the object to be constructed
        [TestMethod]
        public void SidebarViewModel_onStart_Gets_FilteredStocks()
        {
            // Arrange
            IStockReader dataReader = new FakeReader();
            SidebarViewModel viewModel = new SidebarViewModel(dataReader);

            Thread.Sleep(1000);

            // Assert
            Assert.IsNotNull(viewModel.FilteredStocks);
            Assert.AreEqual(2, viewModel.FilteredStocks.Count);
        }

        [TestMethod]
        public void FilterStockSymbols_Are_Filtered()
        {
            //Arrange
            IStockReader dataReader = new FakeReader();
            SidebarViewModel viewModel = new SidebarViewModel(dataReader);

            //Act
            viewModel.FilterStockSymbols("abb");

            //Assert
            Assert.IsNotNull(viewModel.FilteredStocks);
        }
    }
}
