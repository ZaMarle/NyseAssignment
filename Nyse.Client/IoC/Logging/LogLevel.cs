using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    public enum LogLevel
    {
        // Developer specific information
        Debug = 1,

        // Verbose information
        Verbose = 2,

        // General information
        Informative = 3,

        // A warning
        Warning = 4,

        // An error
        Error = 5,

        // A success
        Success = 6
    }
}
