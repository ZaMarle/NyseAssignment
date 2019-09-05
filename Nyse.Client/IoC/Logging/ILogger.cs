using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    // Alogger that will handle log messages from a ILogFactory
    public interface ILogger
    {
        // Handles the logged message being passed in
        void Log(string message, LogLevel level);
    }
}
