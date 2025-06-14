using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class Condition
    {
        [JsonProperty("text")] public string? Text { get; set; }

        [JsonProperty("icon")] public string? Icon { get; set; }

        public string? IconUrl => $"https:{Icon}";

    [JsonProperty("code")]
        public int? Code  { get; set; }
    }
}
