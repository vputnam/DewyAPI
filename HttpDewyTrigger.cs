using System.Diagnostics.CodeAnalysis;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Dewy
{
    public class HttpDewyTrigger
    {
        private readonly ILogger _logger;

        private readonly IOpenWeatherMapController _openWeatherMapController;

        public HttpDewyTrigger(ILoggerFactory loggerFactory, IOpenWeatherMapController openWeatherMapController)
        {
            _openWeatherMapController = openWeatherMapController;
            _logger = loggerFactory.CreateLogger<HttpDewyTrigger>();
        }

        [Function("HttpDewyTrigger")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var lat = req.Query["lat"];
            var lon = req.Query["long"];

            var systemURI = await _openWeatherMapController.GetTemperature(lat, lon).ConfigureAwait(false);

            _logger.LogInformation(systemURI.ToString());

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
