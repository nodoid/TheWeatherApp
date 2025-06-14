using Newtonsoft.Json;

namespace TheWeatherApp.Tests.Models
{
    public class WeatherForecast
    {
        [JsonProperty("location")]
        public LocationModel? Location { get; set; }

        [JsonProperty("current")]
        public Current? Current { get; set; }

        [JsonProperty("forecast")]
        public Forecast? Forecast { get; set; }

        [JsonProperty("alerts")]
        public Alerts? Alerts { get; set; }
    }
}
