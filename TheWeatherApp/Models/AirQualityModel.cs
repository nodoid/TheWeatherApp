using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class AirQuality
    {
        [JsonProperty("co")]
        public double? Co;

        [JsonProperty("no2")]
        public double? No2;

        [JsonProperty("o3")]
        public double? O3;

        [JsonProperty("so2")]
        public double? So2;

        [JsonProperty("pm2_5")]
        public double? Pm25;

        [JsonProperty("pm10")]
        public double? Pm10;

        [JsonProperty("us-epa-index")]
        public int? UsEpaIndex;

        [JsonProperty("gb-defra-index")]
        public int? GbDefraIndex;
    }
}
