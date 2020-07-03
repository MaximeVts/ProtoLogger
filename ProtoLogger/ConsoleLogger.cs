using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoLogger
{
    public class ConsoleLogger : BaseLogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }

        public override void Log(Exception exception)
        {
            var formattedException = FormatException(exception.Message, exception.StackTrace);
            Console.WriteLine(formattedException);
        }
    }
}
