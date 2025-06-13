using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class Alert
    {
        [JsonProperty("headline")]
        public string? Headline  { get; set; }

        [JsonProperty("msgtype")]
        public string? Msgtype  { get; set; }

        [JsonProperty("severity")]
        public string? Severity  { get; set; }

        [JsonProperty("urgency")]
        public string? Urgency  { get; set; }

        [JsonProperty("areas")]
        public string? Areas  { get; set; }

        [JsonProperty("category")]
        public string? Category  { get; set; }

        [JsonProperty("certainty")]
        public string? Certainty  { get; set; }

        [JsonProperty("event")]
        public string? Event  { get; set; }

        [JsonProperty("note")]
        public string? Note  { get; set; }

        [JsonProperty("effective")]
        public string? Effective  { get; set; }

        [JsonProperty("expires")]
        public DateTime? Expires { get; set; }

        [JsonProperty("desc")]
        public string? Desc  { get; set; }

        [JsonProperty("instruction")]
        public string? Instruction { get; set; }
    }

    public class Alerts
    {
        [JsonProperty("alert")]
        public ObservableCollection<Alert> Alert  { get; set; }
    }
}
