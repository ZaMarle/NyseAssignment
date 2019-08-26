using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nyse.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Custom startup so the IoC will load before anything else
        protected override void OnStartup(StartupEventArgs e)
        {
            // Let the base application do what it needs to
            base.OnStartup(e);
            
            // Setup IoC 
            Ioc.Setup();

            // Show the main window
            Current.MainWindow = new MainWindow();

            //Current.MainWindow = Ioc.Kernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
