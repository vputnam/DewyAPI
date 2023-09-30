using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dewy;

var host = new HostBuilder()
.ConfigureFunctionsWorkerDefaults()
.ConfigureServices(s =>
{
    s.AddSingleton<IOpenWeatherMapController, OpenWeatherMapController>();
    s.AddHttpClient<IOpenWeatherMapController, OpenWeatherMapController>();
})
.Build();

await host.RunAsync();