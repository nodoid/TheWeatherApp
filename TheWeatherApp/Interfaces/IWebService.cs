using TheWeatherApp.Models;

namespace TheWeatherApp.Interfaces
{
    public interface IWebService
    {
        Task<WeatherForecast> GetWeather(string location, int days, bool airQuality, bool alerts);
        Task<WeatherForecast> GetWeather(double lat, double lon, int days, bool airQuality, bool alerts);
        Task<TideRoot> GetTides(string location, int days);
        Task<TideRoot> GetTides(double lat, double lng, int days);
    }
}
