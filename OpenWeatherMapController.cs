using System;
using System.Net.Http;
using System.Text;

namespace Dewy
{
    /// Two calsses here - one for database and one for porcessor ?
    public class OpenWeatherMapController
    {
        private string OpenWeatherMapURL = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_KEY");
        private string OpenWeatherMapKey = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_URL");
        private readonly HttpClient _httpClient;
        private string lat;
        private string lon;
        private const string units = "imperial"; 

        public OpenWeatherMapController(HttpClient httpClient, string lat, string lon)
        {
            this._httpClient = httpClient;
            this.lat = lat;
            this.lon = lon;
        }

        private Uri BuildOpenWeatherMapUri()
        {
            StringBuilder stringBuilder = new StringBuilder(OpenWeatherMapURL);
            return new Uri(stringBuilder.ToString());
        }



    }
}