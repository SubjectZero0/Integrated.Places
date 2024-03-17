using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static partial class InfrastructureModule
    {
        public static IServiceCollection AddHangFireJobs(this IServiceCollection services)
        {
            //TODO: investigate a better way to add hangfire
            GlobalConfiguration.Configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseColouredConsoleLogProvider()
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseMemoryStorage();

            return services;
        }
    }
}