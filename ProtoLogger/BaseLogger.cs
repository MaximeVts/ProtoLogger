using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoLogger
{
    public abstract class BaseLogger : IBaseLogger
    {
        private readonly string _dateFormat;
        protected BaseLogger(string dateFormat)
        {
            _dateFormat = dateFormat;
        }
        public abstract void Log(string message);
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
    }
}
