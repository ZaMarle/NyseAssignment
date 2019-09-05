using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    // Logs the messages to the Console
    class ConsoleLogger : ILogger
    {
        // Logs the given message to the system console
        public void Log(string message, LogLevel level)
        {
            // Write message to console
            Console.WriteLine($"[{level}]".PadRight(13, ' ') + message);
        }
    }
}
