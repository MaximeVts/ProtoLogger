using Microsoft.Extensions.DependencyInjection;
using ProtoLogger;
using ProtoLogger.Enums;
using ProtoLogger.Extensions;
using ProtoLogger.Options;

namespace ProtoLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            LoggerOptions protoLoggerOptions = new LoggerOptions
            {
                Target = LoggerTarget.Console,
                ApplicationLogLevel = LogLevel.Error,
                DateFormat = "YYYY mm dd hh:mm:ss",
                //File path can be used when using the file target mode
                //FilePath = @".\test.log"
            };

            var serviceProvider = new ServiceCollection().AddProtoLogger(protoLoggerOptions).BuildServiceProvider();
            var logger = serviceProvider.GetService<IBaseLogger>();

            logger.Log("This is a log in the console");
        }
    }
}
