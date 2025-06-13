using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class Forecast
    {
        [JsonProperty("forecastday")]
        public ObservableCollection<Forecastday>? Forecastday;
    }

    public class Forecastday
    {
        [JsonProperty("date")]
        public string? Date;

        [JsonProperty("date_epoch")]
        public int? DateEpoch;

        [JsonProperty("day")]
        public Day Day;

        [JsonProperty("astro")]
        public Astro? Astro;

        [JsonProperty("hour")]
        public ObservableCollection<Hour>? Hour;
    }
}
