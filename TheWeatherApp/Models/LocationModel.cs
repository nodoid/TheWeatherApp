using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class LocationModel
    {
        [JsonProperty("name")]
        public string? Name;

        [JsonProperty("region")]
        public string? Region;

        [JsonProperty("country")]
        public string? Country;

        [JsonProperty("lat")]
        public double? Lat;

        [JsonProperty("lon")]
        public double? Lon;

        [JsonProperty("tz_id")]
        public string TzId;

        [JsonProperty("localtime_epoch")]
        public int? LocaltimeEpoch;

        [JsonProperty("localtime")]
        public string? Localtime;
    }
}
