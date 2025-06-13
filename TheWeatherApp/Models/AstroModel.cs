using Newtonsoft.Json;

namespace TheWeatherApp.Models
{
    public class Astro
    {
        [JsonProperty("sunrise")]
        public string? Sunrise;

        [JsonProperty("sunset")]
        public string? Sunset;

        [JsonProperty("moonrise")]
        public string? Moonrise;

        [JsonProperty("moonset")]
        public string? Moonset;

        [JsonProperty("moon_phase")]
        public string? MoonPhase;

        [JsonProperty("moon_illumination")]
        public int? MoonIllumination;

        [JsonProperty("is_moon_up")]
        public int? IsMoonUp;

        [JsonProperty("is_sun_up")]
        public int? IsSunUp;
    }

    public class Astronomy
    {
        [JsonProperty("astro")]
        public Astro Astro;
    }
}
