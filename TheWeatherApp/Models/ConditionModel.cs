using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class Condition
    {
        [JsonProperty("text")]
        public string? Text;

        [JsonProperty("icon")]
        public string? Icon;

        [JsonProperty("code")]
        public int? Code;
    }
}
