﻿using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TheWeatherApp.Models
{
    public class Day
    {
        [JsonProperty("maxtemp_c")] public double? MaxtempC { get; set; }

        [JsonProperty("maxtemp_f")] public double? MaxtempF { get; set; }

        [JsonProperty("mintemp_c")] public double? MintempC { get; set; }

        [JsonProperty("mintemp_f")] public double? MintempF { get; set; }

        [JsonProperty("avgtemp_c")] public double? AvgtempC { get; set; }

        [JsonProperty("avgtemp_f")] public double? AvgtempF { get; set; }

        [JsonProperty("maxwind_mph")] public double? MaxwindMph { get; set; }

        [JsonProperty("maxwind_kph")] public double? MaxwindKph { get; set; }

        [JsonProperty("totalprecip_mm")] public double? TotalprecipMm { get; set; }

        [JsonProperty("totalprecip_in")] public double? TotalprecipIn { get; set; }

        [JsonProperty("totalsnow_cm")] public double? TotalsnowCm { get; set; }

        [JsonProperty("avgvis_km")] public double? AvgvisKm { get; set; }

        [JsonProperty("avgvis_miles")] public double? AvgvisMiles { get; set; }

        [JsonProperty("avghumidity")] public double? Avghumidity { get; set; }

        [JsonProperty("tides")] public ObservableCollection<Tides>? AllTides { get; set; }

        public ObservableCollection<Tide2> FullTides
        {
            get => AllTides?.FirstOrDefault()?.Tide2;
        }
        public bool HasTides { get => AllTides != null; }

        [JsonProperty("daily_will_it_rain")]
        public int? DailyWillItRain { get; set; }

        [JsonProperty("daily_chance_of_rain")]
        public int? DailyChanceOfRain { get; set; }

        [JsonProperty("daily_will_it_snow")]
        public int? DailyWillItSnow { get; set; }

        [JsonProperty("daily_chance_of_snow")]
        public int? DailyChanceOfSnow { get; set; }

        [JsonProperty("condition")]
        public Condition? Condition { get; set; }

        [JsonProperty("uv")]
        public double? Uv { get; set; }

        public bool HasAirQuality { get => AirQuality != null; }

        [JsonProperty("air_quality")]
        public AirQuality? AirQuality { get; set; }
    }
}
