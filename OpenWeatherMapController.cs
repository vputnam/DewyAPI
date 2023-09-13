using System;
using System.Net.Http;
using System.Collections.Specialized;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dewy
{
    public class OpenWeatherMapController
    {
        private readonly string OpenWeatherMapURL = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_KEY");
        private readonly string OpenWeatherMapKey = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_URL");
        private readonly HttpClient _httpClient;
        private string lat;
        private string lon;
        private const string units = "imperial"; 

        public OpenWeatherMapController(HttpClient httpClient, string lat, string lon)
        {
            this._httpClient = httpClient;
            this.lat = lat;
            this.lon = lon;
            _httpClient.BaseAddress = new Uri(OpenWeatherMapURL);
        }

        private Uri BuildOpenWeatherMapUri()
        {
            var queryParams = new NameValueCollection();

            // Add query parameters
            queryParams.Add("lat", lat);
            queryParams.Add("lon", lon);
            queryParams.Add("units", units);

            // Add the API key as a query parameter
            queryParams.Add("appid", OpenWeatherMapKey);

            // Build the complete URL with query parameters
            var uriBuilder = new UriBuilder(OpenWeatherMapURL);
            uriBuilder.Query = string.Join("&", queryParams.AllKeys
                .Select(key => $"{key}={System.Web.HttpUtility.UrlEncode(queryParams[key])}"));
            return uriBuilder.Uri;

        }

        public async Task<string> GetTemperature(string lat, string lon)
        {
            Uri tempUri = BuildOpenWeatherMapUri(); // is this a good way of initalising? 
            // var result = await _httpClient.GetAsync(tempUri).ConfigureAwait(false);
            // string jsonString = JsonSerializer.Serialize(result);
            // OneCallResponse oneCallResponse = JsonSerializer.Deserialize<OneCallResponse>(jsonString);

            return tempUri.AbsolutePath;

        }

    }
}