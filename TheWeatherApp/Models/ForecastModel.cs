using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public ObservableCollection<Forecastday>? Forecastday { get; set; }
    }

    public class Forecastday
    {
        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("date_epoch")]
        public int? DateEpoch { get; set; }

        [JsonProperty("day")]
        public Day Day { get; set; }

        [JsonProperty("astro")]
        public Astro? Astro { get; set; }

        [JsonProperty("hour")]
        public ObservableCollection<Hour>? Hour { get; set; }
    }
}
