using ProtoLogger.Enums;
using System;

namespace ProtoLogger
{
    public class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger(LogLevel logLevel = LogLevel.Error, string dateFormat = "")
            :base(logLevel, dateFormat)
        {
        }

        public override void Log(string message, LogLevel logLevel = LogLevel.Error)
        {
            if (ShouldWriteLog(logLevel))
            {
                SendToConsoleOutput(FormatLogs(message, DateTime.Now));
            }
        }

        public override void Log(Exception exception)
        {
            SendToConsoleOutput(FormatLogs(exception, DateTime.Now));
        }

        private void SendToConsoleOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}
