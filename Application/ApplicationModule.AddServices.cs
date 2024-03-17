using Application.Decorators;
using Application.MessageBus.EventHandlers;
using Application.Services;
using Domain.Aggregates.Coordinates;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static partial class ApplicationModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped<ICoordinatesService, CoordinatesService>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationDecorator<,>));

            services.AddScoped(typeof(IHandleMessages<CoordinatesAdded>), typeof(CoordinatesAddedEventHandler));

            return services;
        }
    }
}