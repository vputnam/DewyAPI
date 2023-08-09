
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Dewy
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<OpenWeatherMapController>();
            services.AddScoped<HttpClient>();
            

        }

    }
}