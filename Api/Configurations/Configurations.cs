namespace Api.Configurations
{
    public class Configurations
    {
        public class FeedApiSettings
        {
            public string ApiKey { get; set; }
            public string ApiHost { get; set; }
            public string Url { get; set; }
        }

        public class NServiceBusSettings
        {
            public string TransportConnectionString { get; set; }
            public string EndpointName { get; set; }
        }
    }
}