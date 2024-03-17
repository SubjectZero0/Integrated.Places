using Gateway.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway
{
    public static partial class GatewayModule
    {
        public static IServiceCollection RegisterHttpClients(this IServiceCollection services, string ApiKey, string ApiHost, string Url)
        {
            services.AddTransient<IPlacesClient, PlacesClient>();

            services.AddHttpClient<PlacesClient>(cfg =>
            {
                cfg.BaseAddress = new Uri(Url);
                cfg.DefaultRequestHeaders.Clear();
                cfg.DefaultRequestHeaders.Add("X-RapidAPI-Key", ApiKey);
                cfg.DefaultRequestHeaders.Add("X-RapidAPI-Host", ApiHost);
            });

            return services;
        }
    }
}