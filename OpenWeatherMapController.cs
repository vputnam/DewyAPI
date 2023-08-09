using System;
using System.Net.Http;
using System.Text;

namespace Dewy
{
    /// Two calsses here - one for database and one for porcessor ?
    public class OpenWeatherMapController
    {
        private string OpenWeatherMapURL = Environment.GetEnvironmentVariable("OPEN_WEATHER_MAP_KEY"); // might move to start up? 
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
            stringBuilder.Append("?lat=");
            stringBuilder.Append(lat);
            return new Uri(stringBuilder.ToString());
        }



    }
}