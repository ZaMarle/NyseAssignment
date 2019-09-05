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
        // The kernal for the ioc container
        public static IKernel Kernel { get; set; } = new StandardKernel();

        // A shortcut to acces the ILogFactory
        public static ILogFactory Logger => Kernel.Get<ILogFactory>();

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

            // Bind a logger
            Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory());
        }

        private static void BindViewModels()
        {
            // Binds an instance on WindowViewModel to the kernal
            Kernel.Bind<WindowViewModel>().ToConstant(new WindowViewModel());
        }
    }
}
