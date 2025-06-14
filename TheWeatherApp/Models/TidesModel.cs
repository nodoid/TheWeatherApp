using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class TideRoot
    {
        [JsonProperty("location")]
        public LocationModel? Location  { get; set; }

        [JsonProperty("forecast")]
        public Forecast? Forecast { get; set; }
    }

    public class Tide2
    {
        [JsonProperty("tide_time")]
        public string? TideTime { get; set; }

        [JsonProperty("tide_height_mt")]
        public string? TideHeightMt { get; set; }

        [JsonProperty("tide_type")]
        public string? TideType { get; set; }
    }

}
