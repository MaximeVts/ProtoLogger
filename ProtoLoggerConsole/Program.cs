using Microsoft.Extensions.DependencyInjection;
using ProtoLogger;
using ProtoLogger.Extensions;
using ProtoLogger.Options;
using System;

namespace ProtoLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            LoggerOptions protoLoggerOptions = new LoggerOptions
            {
                Target = LoggerTarget.Console,
                DateFormat = "YYYY mm dd hh:mm:ss"
            };

            var serviceProvider = new ServiceCollection().AddProtoLogger(protoLoggerOptions).BuildServiceProvider();
            var logger = serviceProvider.GetService<IBaseLogger>();

            logger.Log("This is a log writing into a file");

            Console.WriteLine("Hello World!");
        }
    }
}
