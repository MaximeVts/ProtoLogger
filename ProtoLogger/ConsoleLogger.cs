using System;

namespace ProtoLogger
{
    public class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger(string dateFormat = "")
            :base(dateFormat)
        {

        }
        public override void Log(string message)
        {
            SendToConsoleOutput(FormatLogs(message, DateTime.Now));
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
