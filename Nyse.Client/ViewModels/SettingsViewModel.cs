using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Nyse.Client
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Members

        // Performance counters
        PerformanceCounter HddSpaceRemaining = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
        PerformanceCounter ProcessorUtilisation = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        PerformanceCounter MemoryUtilisation = new PerformanceCounter("Memory", "Available MBytes");

        // Processor utilisation performance counter
        private string _processor;
        public string Processor
        {
            get
            {
                return _processor;
            }
            set
            {
                _processor = value;
                OnPropertyChanged("Processor");
            }
        }

        // Memory utilisation performance counter
        private string _memory;
        public string Memory
        {
            get
            {
                return _memory;
            }
            set
            {
                _memory = value;
                OnPropertyChanged("Memory");
            }
        }

        // Hard Disk Drive utilisation performance counter
        private string _hdd;
        public string HDD
        {
            get
            {
                return _hdd;
            }
            set
            {
                _hdd = value;
                OnPropertyChanged("HDD");
            }
        }

        #endregion

        #region Constructor

        public SettingsViewModel()
        {
            // Feteches the performance counters
            FetchPerformance();
        }

        #endregion

        #region Methods

        // Sets the performance counter members to their value every second while Active = true
        private async void FetchPerformance()
        {
            // Checks to see if the object is correct
            if (Active == true)
            {
                // %
                Processor = (int)ProcessorUtilisation.NextValue() + " " + "%";
                // MB
                Memory = (int)MemoryUtilisation.NextValue() + " " + "MB";
                // %
                HDD = (int)HddSpaceRemaining.NextValue() + " " + "%";

                Console.WriteLine(Processor);
                Console.WriteLine(Memory);
                Console.WriteLine(HDD);

                await Task.Delay(1000);

                FetchPerformance();
            }
            else
            {
                Console.WriteLine("Deactivated setting view model");
            }
        }

        #endregion
    }
}
