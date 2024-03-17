using Application.Decorators;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static partial class ApplicationModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFeedService, FeedService>();
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationDecorator<,>));

            return services;
        }
    }
}