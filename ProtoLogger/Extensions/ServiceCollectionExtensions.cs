using Microsoft.Extensions.DependencyInjection;
using ProtoLogger.Options;

namespace ProtoLogger.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddProtoLogger(this IServiceCollection serviceCollection, LoggerOptions options)
        {
            switch (options.Target)
            {
                case LoggerTarget.File:
                    serviceCollection.AddSingleton<IBaseLogger, FileLogger>(x => new FileLogger(options.FilePath));
                    break;
                case LoggerTarget.Database:
                    //todo setup here
                    break;
                case LoggerTarget.Console:
                default:
                    serviceCollection.AddSingleton<IBaseLogger, ConsoleLogger>();                
                    break;
            }
            return serviceCollection;
        }        
    }
}
