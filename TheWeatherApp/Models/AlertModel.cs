using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class Alert
    {
        [JsonProperty("headline")]
        public string? Headline;

        [JsonProperty("msgtype")]
        public string? Msgtype;

        [JsonProperty("severity")]
        public string? Severity;

        [JsonProperty("urgency")]
        public string? Urgency;

        [JsonProperty("areas")]
        public string? Areas;

        [JsonProperty("category")]
        public string? Category;

        [JsonProperty("certainty")]
        public string? Certainty;

        [JsonProperty("event")]
        public string? Event;

        [JsonProperty("note")]
        public string? Note;

        [JsonProperty("effective")]
        public string? Effective;

        [JsonProperty("expires")]
        public DateTime? Expires;

        [JsonProperty("desc")]
        public string? Desc;

        [JsonProperty("instruction")]
        public string? Instruction;
    }

    public class Alerts
    {
        [JsonProperty("alert")]
        public ObservableCollection<Alert> Alert;
    }
}
