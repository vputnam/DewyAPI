using Microsoft.Extensions.DependencyInjection;

namespace Dewy
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // to do - create interface for ApiClientServices 
            services.AddSingleton<OpenWeatherMapController>();
            services.AddHttpClient<OpenWeatherMapController>();
        }

    }
}
