namespace Api
{
    public static partial class Program
    {
        public static WebApplicationBuilder AddAppSettings(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder;
        }
    }
}