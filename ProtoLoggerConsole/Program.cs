using Microsoft.Extensions.DependencyInjection;
using ProtoLogger;
using ProtoLogger.Extensions;
using System;

namespace ProtoLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddProtoLoggerForConsole().BuildServiceProvider();
            var logger = serviceProvider.GetService<IBaseLogger>();

            logger.Log("This is a log writing into a file");

            Console.WriteLine("Hello World!");
        }
    }
}
