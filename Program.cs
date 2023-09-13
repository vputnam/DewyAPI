using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dewy;

var host = new HostBuilder()
.ConfigureFunctionsWorkerDefaults()
.ConfigureServices(s =>
{
    s.AddScoped<OpenWeatherMapController>();
    s.AddHttpClient<OpenWeatherMapController>();
})
.Build();

await host.RunAsync();