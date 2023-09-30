using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dewy
{
    public class OneCallResponse
    {
        [JsonProperty("lat")]
        public int Lat { get; set; }

        [JsonProperty("lon")]
        public int Long { get; set; }

        [JsonProperty("current")]
        public Current? current { get; set; }

    }

    public class Current 
    {

        [JsonProperty("uvi")]
        public int UVI { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp")]
        public int Temp { get; set; }
    }
}