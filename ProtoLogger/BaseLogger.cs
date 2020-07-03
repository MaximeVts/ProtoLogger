using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoLogger
{
    public abstract class BaseLogger : IBaseLogger
    {        
        public abstract void Log(string message);
        public abstract void Log(Exception exception);
        protected virtual string FormatException(string message, string stackTrace)
        {
            return $"{message} \r\n {stackTrace}";
        }        
    }
}
