using Microsoft.Extensions.DependencyInjection;

namespace ProtoLogger.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProtoLoggerForFile(this IServiceCollection serviceCollection, string filePath)
        {
            serviceCollection.AddSingleton<IBaseLogger, FileLogger>(x => new FileLogger(filePath));
            return serviceCollection;
        }

        public static IServiceCollection AddProtoLoggerForDatabase(this IServiceCollection serviceCollection,string connectionString)
        {
            //todo setup here
            return serviceCollection;
        }

        public static IServiceCollection AddProtoLoggerForConsole(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IBaseLogger, ConsoleLogger>();

            return serviceCollection;
        }
    }
}
