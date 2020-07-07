using ProtoLogger.Enums;
using System;

namespace ProtoLogger
{
    public interface IBaseLogger
    {
        /// <summary>
        /// Log an exception
        /// </summary>
        /// <param name="exception">the Exception to be logged by the system</param>
        void Log(Exception exception);
        /// <summary>
        /// Log an information
        /// </summary>
        /// <param name="message">the message to be logged</param>
        /// <param name="logLevel">the log level of this specific log</param>
        void Log(string message, LogLevel logLevel = LogLevel.Error);        
    }
}