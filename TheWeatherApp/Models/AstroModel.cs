﻿using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class Astro
    {
        [JsonProperty("sunrise")]
        public string? Sunrise  { get; set; }

        [JsonProperty("sunset")]
        public string? Sunset  { get; set; }

        [JsonProperty("moonrise")]
        public string? Moonrise  { get; set; }

        [JsonProperty("moonset")]
        public string? Moonset  { get; set; }

        [JsonProperty("moon_phase")]
        public string? MoonPhase  { get; set; }

        [JsonProperty("moon_illumination")]
        public int? MoonIllumination  { get; set; }

        [JsonProperty("is_moon_up")]
        public int? IsMoonUp  { get; set; }

        [JsonProperty("is_sun_up")]
        public int? IsSunUp  { get; set; }
    }

    public class Astronomy
    {
        [JsonProperty("astro")]
        public Astro Astro  { get; set; }
    }
}
