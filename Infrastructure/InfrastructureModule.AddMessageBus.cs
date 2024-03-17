using Application.MessageBus;
using Domain;
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

            endpointConfiguration.Conventions().DefiningEventsAs(type => typeof(DomainEvent).IsAssignableFrom(type));

            var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
            transport.ConnectionString(transportConnectionString);
            transport.UseDirectRoutingTopology(QueueType.Classic);

            var endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();
            services.AddSingleton<IMessageSession>(endpoint);

            services.AddScoped<IEventsHub, EventsHub>();

            //TODO: find a way to correctly setup rabbitmq

            return services;
        }
    }
}