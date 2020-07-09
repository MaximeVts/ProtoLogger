using Microsoft.Extensions.DependencyInjection;
using ProtoLogger;
using ProtoLogger.Enums;
using ProtoLogger.Extensions;
using ProtoLogger.Options;
using SqliteDb;
using System;
using System.IO;

namespace ProtoLoggerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LogConsoleExample();
            LogFileExample();
            LogDatabaseExample();
        }

         static void LogConsoleExample()
        {
            LoggerOptions protoLoggerOptions = new LoggerOptions
            {
                Target = LoggerTarget.Console,
                ApplicationLogLevel = LogLevel.warning,
                DateFormat = "YYYY mm dd hh:mm:ss"               
            };
            var serviceProvider = new ServiceCollection().AddProtoLogger(protoLoggerOptions).BuildServiceProvider();
            var logger = serviceProvider.GetService<IBaseLogger>();
            //this log will appear in the console
            logger.Log("a log for the console", LogLevel.Error);
            //this log will not appear because of the global logLevel
            logger.Log("a log for the console that won't appear", LogLevel.Trace);
        }

        private static void LogFileExample()
        {
            LoggerOptions protoLoggerOptions = new LoggerOptions
            {
                Target = LoggerTarget.File,
                ApplicationLogLevel = LogLevel.Error,
                DateFormat = "YYYY mm dd hh:mm:ss",
                FilePath = @".\test.log"
            };
            var serviceProvider = new ServiceCollection().AddProtoLogger(protoLoggerOptions).BuildServiceProvider();
            var logger = serviceProvider.GetService<IBaseLogger>();
            //this log will appear in the created file
            logger.Log("a log for the console", LogLevel.Error);            
        }

        private static void LogDatabaseExample()
        {
            //delete the DB if previously existed
            if (File.Exists("local.db"))
            {
                File.Delete("local.db");
            }
            string connectionString = "Data Source=local.db";
            LoggerOptions protoLoggerOptions = new LoggerOptions
            {
                Target = LoggerTarget.Database,
                ApplicationLogLevel = LogLevel.Trace,
                DateFormat = "YYYY mm dd hh:mm:ss",
                ConnectionString = connectionString
            };
            var serviceProvider = new ServiceCollection().AddProtoLogger(protoLoggerOptions).BuildServiceProvider();
            var logger = serviceProvider.GetService<IBaseLogger>();
            //this log will appear in the sqllite database (file mode)
            var db = new DbRepository(connectionString);
            logger.Log("a log for the database", LogLevel.Trace);            
            //We can get the log from database
            var log = db.GetFirstLog();            
            Console.WriteLine($"Message from DB : {log.Message}");
        }

    }
}
