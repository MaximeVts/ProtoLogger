using Microsoft.Extensions.DependencyInjection;
using ProtoLogger.Options;
using System;
using System.Security.Cryptography.X509Certificates;

namespace ProtoLogger.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the logger to the application and apply the given options
        /// </summary>
        /// <param name="serviceCollection">The DI service provided in .NET Core</param>
        /// <param name="options">Options that will be used to setup the logger</param>        
        public static IServiceCollection AddProtoLogger(this IServiceCollection serviceCollection, LoggerOptions options)
        {
            switch (options.Target)
            {
                case LoggerTarget.File:                    
                    serviceCollection.AddSingleton<IBaseLogger, FileLogger>(x => new FileLogger(options.FilePath, options.ApplicationLogLevel));
                    break;
                case LoggerTarget.Database:                    
                    serviceCollection.AddSingleton<IBaseLogger, DatabaseLogger>(x => new DatabaseLogger(options.ConnectionString, options.ApplicationLogLevel));
                    break;
                case LoggerTarget.Console:
                default:
                    serviceCollection.AddSingleton<IBaseLogger, ConsoleLogger>(x => new ConsoleLogger(options.ApplicationLogLevel));                
                    break;
            }
            return serviceCollection;
        }        
    }
}
