using Application.MessageBus;
using Domain.Aggregates.Coordinates;
using Infrastructure.MessageBus;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace Infrastructure
{
    public static partial class InfrastructureModule
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string transportConnectionString, string endpointName)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName);

            endpointConfiguration.Conventions().DefiningEventsAs(type => type == typeof(CoordinatesAdded));
            endpointConfiguration.AutoSubscribe();

            endpointConfiguration.UseSerialization<XmlSerializer>();
            endpointConfiguration.AddDeserializer<XmlSerializer>();

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString(transportConnectionString);
            transport.UseDirectRoutingTopology(QueueType.Classic);

            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            services.AddSingleton<IMessageSession>(endpoint);

            services.AddScoped<IEventsHub, EventsHub>();

            return services;
        }
    }
}