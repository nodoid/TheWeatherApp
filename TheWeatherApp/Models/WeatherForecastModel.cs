using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class WeatherForecast
    {
        [JsonProperty("location")]
        public LocationModel? Location;

        [JsonProperty("current")]
        public Current? Current;

        [JsonProperty("forecast")]
        public Forecast? Forecast;

        [JsonProperty("alerts")]
        public Alerts? Alerts;
    }
}
