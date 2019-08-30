 using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    //The IoC container for the application
    public static class Ioc
    {
        public static IKernel Kernel { get; set; } = new StandardKernel();

        // Sets up the IoC container, binds all information
        // Musts be called as soon as app starts to ensure the services can be found
        public static void Setup()
        {
            ConfigureContainer();
            BindViewModels(); 
        }

        private static void ConfigureContainer()
        {
            // Binds an instance of the Data service to IStockReader
            Kernel.Bind<IStockReader>().ToConstant(new CachingReader(new ApiStockReader()));
        }

        private static void BindViewModels()
        {
            // Binds an instance on WindowViewModel to the kernal
            Kernel.Bind<WindowViewModel>().ToConstant(new WindowViewModel());
        }
    }
}
