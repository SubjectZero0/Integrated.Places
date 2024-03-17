using Gateway;
using static Api.Configurations.Configurations;

namespace Api
{
    public static partial class Program
    {
        public static WebApplicationBuilder AddGatewayModule(this WebApplicationBuilder builder)
        {
            var feedApiSettings = builder.Configuration.GetSection(nameof(FeedApiSettings)).Get<FeedApiSettings>() ?? throw new ArgumentNullException(nameof(FeedApiSettings));

            GatewayModule.RegisterHttpClients(builder.Services, feedApiSettings.ApiKey, feedApiSettings.ApiHost, feedApiSettings.Url);

            return builder;
        }
    }
}