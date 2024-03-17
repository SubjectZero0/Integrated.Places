using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace Infrastructure
{
    public static partial class InfrastructureModule
    {
        public static IServiceCollection AddNServiceBus(this IServiceCollection services, string transportConnectionString, string endpointName)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();

            transport.ConnectionString(transportConnectionString);
            transport.UseConventionalRoutingTopology(QueueType.Classic);

            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            services.AddSingleton<IMessageSession>(endpoint);

            return services;
        }
    }
}