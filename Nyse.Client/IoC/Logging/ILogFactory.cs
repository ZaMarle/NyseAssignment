using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    //holds a bunch of loggers to log messages for the user
    public interface ILogFactory
    {
        #region Public Properties

        // The level of logging to output
        LogFactoryLevel LogOutputLevel { get; set; }

        // If true, includes the origin of where the log message was logged from
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Events

        // Fires whenever a new log arrives
        event Action<(string Message, LogLevel Level)> NewLog;

        #endregion

        #region Methods

        // Adds specific logger to factory
        void AddLogger(ILogger logger);

        // Removes the specified logger from this factory
        void RemoveLogger(ILogger logger);

        // Logs the specific message to all loggers in this factory
        void Log(
            string message,
            LogLevel level = LogLevel.Informative,
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0);

        #endregion
    }
}
