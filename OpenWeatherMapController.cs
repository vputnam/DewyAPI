using System;
using System.Net.Http;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Dewy
{
    public class OpenWeatherMapController : IOpenWeatherMapController
    {
        private readonly string OpenWeatherMapURL;  
        private readonly string OpenWeatherMapKey; 
        private const string units = "imperial";
        private HttpClient httpClient;
        public OpenWeatherMapController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            OpenWeatherMapURL = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_URL");
            OpenWeatherMapKey = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_KEY");
        }

        private Uri BuildOpenWeatherMapUri(string lat, string lon)
        {
            var queryParams = new NameValueCollection();

            // Add query parameters
            queryParams.Add("lat", lat);
            queryParams.Add("lon", lon);
            queryParams.Add("units", units);

            // Add the API key as a query parameter
            queryParams.Add("appid", OpenWeatherMapKey);

            // Build the complete URL with query parameters
            UriBuilder uriBuilder = new UriBuilder(OpenWeatherMapURL);
            uriBuilder.Query = string.Join("&", queryParams.AllKeys
                .Select(key => $"{key}={System.Web.HttpUtility.UrlEncode(queryParams[key])}"));
            return uriBuilder.Uri;
 
        }

        public async Task<OneCallResponse> GetTemperature(string lat, string lon)
        {
            Uri tempUri = BuildOpenWeatherMapUri(lat, lon);  
            var result = await httpClient.GetAsync(tempUri).ConfigureAwait(false);
            string jsonString = JsonSerializer.Serialize(result);
            OneCallResponse oneCallResponse = JsonSerializer.Deserialize<OneCallResponse>(jsonString);

            return oneCallResponse;

        }

    }
}