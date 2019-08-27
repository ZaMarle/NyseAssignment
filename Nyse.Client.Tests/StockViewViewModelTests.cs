using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nyse.Client.Tests
{
    [TestClass]
    public class StockViewViewModelTests
    {
        // Tests to check the stock Property is populated on construction 
        [TestMethod]
        public void Stocks_loaded_when_class_constructed()
        {
            // Arrange
            var reader = new FakeReader();
            var viewModel = new StockViewViewModel("abb", reader);

            // Act
            Thread.Sleep(1000);

            // Assert
            Assert.IsNotNull(viewModel.Stock);
        }
    }
}
