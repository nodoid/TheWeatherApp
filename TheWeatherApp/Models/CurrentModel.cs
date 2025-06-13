using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class Current
    {
        [JsonProperty("last_updated_epoch")]
        public int? LastUpdatedEpoch;

        [JsonProperty("last_updated")]
        public string LastUpdated;

        [JsonProperty("temp_c")]
        public double? TempC;

        [JsonProperty("temp_f")]
        public double? TempF;

        [JsonProperty("is_day")]
        public int? IsDay;

        [JsonProperty("condition")]
        public Condition? Condition;

        [JsonProperty("wind_mph")]
        public double? WindMph;

        [JsonProperty("wind_kph")]
        public double? WindKph;

        [JsonProperty("wind_degree")]
        public int? WindDegree;

        [JsonProperty("wind_dir")]
        public string? WindDir;

        [JsonProperty("pressure_mb")]
        public double? PressureMb;

        [JsonProperty("pressure_in")]
        public double? PressureIn;

        [JsonProperty("precip_mm")]
        public double? PrecipMm;

        [JsonProperty("precip_in")]
        public double? PrecipIn;

        [JsonProperty("humidity")]
        public int? Humidity;

        [JsonProperty("cloud")]
        public int? Cloud;

        [JsonProperty("feelslike_c")]
        public double? FeelslikeC;

        [JsonProperty("feelslike_f")]
        public double? FeelslikeF;

        [JsonProperty("windchill_c")]
        public double? WindchillC;

        [JsonProperty("windchill_f")]
        public double? WindchillF;

        [JsonProperty("heatindex_c")]
        public double? HeatindexC;

        [JsonProperty("heatindex_f")]
        public double? HeatindexF;

        [JsonProperty("dewpoint_c")]
        public double? DewpointC;

        [JsonProperty("dewpoint_f")]
        public double? DewpointF;

        [JsonProperty("vis_km")]
        public double? VisKm;

        [JsonProperty("vis_miles")]
        public double? VisMiles;

        [JsonProperty("uv")]
        public double? Uv;

        [JsonProperty("gust_mph")]
        public double? GustMph;

        [JsonProperty("gust_kph")]
        public double? GustKph;

        [JsonProperty("air_quality")]
        public AirQuality? AirQuality;
    }

}
