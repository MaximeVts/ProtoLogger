using ProtoLogger.Enums;
using System;

namespace ProtoLogger
{
    public abstract class BaseLogger : IBaseLogger
    {
        private readonly string _dateFormat;
        private readonly LogLevel _applicationLogLevel;
        
        protected BaseLogger(LogLevel logLevel, string dateFormat)
        {
            _applicationLogLevel = logLevel;
            _dateFormat = dateFormat;
        }
        public abstract void Log(string message, LogLevel logLevel = LogLevel.Error);
        public abstract void Log(Exception exception);
        protected virtual string FormatLogs(string message, DateTime dateOfLog)
        {
            if (string.IsNullOrWhiteSpace(_dateFormat))
            {
                return $"[{dateOfLog.ToShortDateString()} {dateOfLog.ToShortTimeString()}] : {message}";
            }
            else
            {
                return $"[{dateOfLog.ToString(_dateFormat)}] : {message}";
            }
        }
        protected virtual string FormatLogs(Exception exception, DateTime dateOfLog)
        {
            if (string.IsNullOrWhiteSpace(_dateFormat))
            {
                return $"[{dateOfLog.ToShortDateString()} {dateOfLog.ToShortTimeString()}] : {exception.Message} \r\n {exception.StackTrace}";
            }
            else
            {
                return $"[{dateOfLog.ToString(_dateFormat)}] : {exception.Message} \r\n {exception.StackTrace}";
            }
        }

        protected bool ShouldWriteLog(LogLevel logLevel)
        {
            return _applicationLogLevel >= logLevel;            
        }
    }
}
