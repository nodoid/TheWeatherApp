using Newtonsoft.Json;
using System.Net;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;

namespace TheWeatherApp.Services
{
    public class WebService : IWebService
    {
        public async Task<TideRoot> GetTides(string location, int days)
        {
            var q = new List<string> { $"q={location}", $"days={days}"};
            var snd = FormQuery("marine", q);
            return await GetSingleItem<TideRoot>(snd);
        }

        public async Task<TideRoot> GetTides(double lat, double lng, int days)
        {
            var q = new List<string> { $"q={lat},{lng}", $"days={days}"};
            var snd = FormQuery("marine", q);
            return await GetSingleItem<TideRoot>(snd);
        }

        public async Task<WeatherForecast> GetWeather(string location, int days, bool airQuality, bool alerts)
        {
            var q = new List<string> { $"q={location}", $"days={days}", $"aqi={(airQuality ? "yes" : "no")}",
            $"alerts={(alerts ? "yes" : "no")}"};
            var snd = FormQuery("forecast", q);
            return await GetSingleItem<WeatherForecast>(snd);
        }

        public async Task<WeatherForecast> GetWeather(double lat, double lon, int days = 1, bool airQuality = false, bool alerts = false)
        {
            var q = new List<string> { $"q={lat},{lon}", $"days={days}", $"aqi={(airQuality ? "yes" : "no")}",
            $"alerts={(alerts ? "yes" : "no")}"};
            var snd = FormQuery("forecast", q);
            return await GetSingleItem<WeatherForecast>(snd);
        }

        string FormQuery(string api, List<string> pars)
        {
            var touse = $"{Constants.Constants.BaseUrl}/{api}.json&key={Constants.Constants.APIKey}&";
            foreach (var par in pars)
                touse += par;
            return touse;
        }

        async Task<T> GetSingleItem<T>(string api)
        {
            var result = Activator.CreateInstance<T>();
            try
            {
                var client = new HttpClient();
                var send = await client.GetAsync(api);

                if (send.StatusCode == HttpStatusCode.OK)
                {
                    var res = await send.Content.ReadAsStringAsync();

                    result = JsonConvert.DeserializeObject<T>(res);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.WriteLine($"Exception : {ex.Message} : {ex.InnerException?.Message}");
#endif
            }
            return result;
        }
    }
}
