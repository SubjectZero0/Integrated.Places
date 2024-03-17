using Application.Queries.Feed;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static partial class ApplicationModule
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<IValidator<GetCoordinatesByName>, GetCoordinatesByNameValidator>();

            return services;
        }
    }
}