using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Nyse.Client
{
    // The standard log factory for NYSE Client
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        // The list of loggers in this factory
        protected List<ILogger> mLoggers = new List<ILogger>();

        // A lock for the logger list to keep it thread safe
        protected object mLoggersLock = new object();

        #endregion

        #region Public Properties

        // The level of logging to output
        public LogFactoryLevel LogOutputLevel { get; set; }

        // If true, includes the origin of where the log message was logged from
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Public Events

        // Fires whenever a new log arrives
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Constructor

        // Default constructor
        public BaseLogFactory()
        {
            // Add console logger
            AddLogger(new ConsoleLogger());
        }

        #endregion

        #region Public Methods

        //Adds the specific logger to this factory
        public void AddLogger(ILogger logger)
        {
            // Log the list so it is thread safe
            lock (mLoggersLock)
            {
                // If the logger is not already in the list...
                if (!mLoggers.Contains(logger))
                    // Add the logger to the list
                    mLoggers.Add(logger);
            }
        }

        // Removes the specified logger from this factory
        public void RemoveLogger(ILogger logger)
        {
            // Log the list so it is thread safe
            lock (mLoggersLock)
            {
                // If the logger is in the list...
                if (mLoggers.Contains(logger))
                    // Remove the logger to the list
                    mLoggers.Remove(logger);
            }
        }

        // Logs the specific message to all loggers in this factory
        public void Log(
            string message,
            LogLevel level = LogLevel.Informative, 
            [CallerMemberName] string origin = "", 
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            // If we should not log the message as the level is too low
            if ((int)level < (int)LogOutputLevel)
                return;

            // If the user wants to know where the llog originated from..
            if (IncludeLogOriginDetails)
                message = $"[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]{System.Environment.NewLine}{message}";

            // Logs to all loggers
            mLoggers.ForEach(logger => logger.Log(message, level));

            // Inform listeners
            NewLog.Invoke((message, level));
        }

        #endregion
    }
}
