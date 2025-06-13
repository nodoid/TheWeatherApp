using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class TideRoot
    {
        [JsonProperty("location")]
        public LocationModel Location;

        [JsonProperty("forecast")]
        public Forecast Forecast;
    }


    public class Tides
    {
        [JsonProperty("tide")]
        public ObservableCollection<Tide2>? Tide;
    }

    public class Tide2
    {
        [JsonProperty("tide_time")]
        public string? TideTime;

        [JsonProperty("tide_height_mt")]
        public string? TideHeightMt;

        [JsonProperty("tide_type")]
        public string? TideType;
    }

}
