using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    public enum LogFactoryLevel
    {
        // Logs everything
        Debug = 1,

        // Logs all info except debug info
        Verbose = 2,

        // Logs all informative message, ignoring any debug and verbose messages
        Informative = 3,

        // Logs only critical errors and warnings, no general information
        Critical = 4,

        // The logger will never oputput anything
        Nothing = 7
    }
}
