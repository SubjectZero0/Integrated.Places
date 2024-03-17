using Application;

namespace Api
{
    public static partial class Program
    {
        public static WebApplicationBuilder AddApplicationModule(this WebApplicationBuilder builder)
        {
            ApplicationModule.AddMediatr(builder.Services);
            ApplicationModule.AddServices(builder.Services);

            return builder;
        }
    }
}