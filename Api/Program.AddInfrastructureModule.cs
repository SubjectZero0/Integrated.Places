﻿using Infrastructure;
using static Api.Configurations.Configurations;

namespace Api
{
    public static partial class Program
    {
        public static WebApplicationBuilder AddInfrastructureModule(this WebApplicationBuilder builder)
        {
            var nServiceBusSettings = builder.Configuration.GetSection(nameof(NServiceBusSettings)).Get<NServiceBusSettings>() ?? throw new ArgumentNullException(nameof(NServiceBusSettings));

            InfrastructureModule.AddMessageBus(builder.Services, nServiceBusSettings.TransportConnectionString, nServiceBusSettings.EndpointName);
            InfrastructureModule.AddHangFireJobs(builder.Services);

            return builder;
        }
    }
}