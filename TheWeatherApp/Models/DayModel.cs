using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class Day
    {
        [JsonProperty("maxtemp_c")]
        public double? MaxtempC;

        [JsonProperty("maxtemp_f")]
        public double? MaxtempF;

        [JsonProperty("mintemp_c")]
        public double? MintempC;

        [JsonProperty("mintemp_f")]
        public double? MintempF;

        [JsonProperty("avgtemp_c")]
        public double? AvgtempC;

        [JsonProperty("avgtemp_f")]
        public double? AvgtempF;

        [JsonProperty("maxwind_mph")]
        public double? MaxwindMph;

        [JsonProperty("maxwind_kph")]
        public double? MaxwindKph;

        [JsonProperty("totalprecip_mm")]
        public double? TotalprecipMm;

        [JsonProperty("totalprecip_in")]
        public double? TotalprecipIn;

        [JsonProperty("totalsnow_cm")]
        public double? TotalsnowCm;

        [JsonProperty("avgvis_km")]
        public double? AvgvisKm;

        [JsonProperty("avgvis_miles")]
        public double? AvgvisMiles;

        [JsonProperty("avghumidity")]
        public int? Avghumidity;

        [JsonProperty("tides")]
        public ObservableCollection<Tides>? Tides;

        public bool HasTides { get => Tides != null; }

        [JsonProperty("daily_will_it_rain")]
        public int? DailyWillItRain;

        [JsonProperty("daily_chance_of_rain")]
        public int? DailyChanceOfRain;

        [JsonProperty("daily_will_it_snow")]
        public int? DailyWillItSnow;

        [JsonProperty("daily_chance_of_snow")]
        public int? DailyChanceOfSnow;

        [JsonProperty("condition")]
        public Condition? Condition;

        [JsonProperty("uv")]
        public double? Uv;

        public bool HasAirQuality { get => AirQuality != null; }

        [JsonProperty("air_quality")]
        public AirQuality? AirQuality;
    }
}
