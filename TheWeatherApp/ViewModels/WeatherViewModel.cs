using CommunityToolkit.Mvvm.ComponentModel;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;
using TheWeatherApp.Views.Popups;

namespace TheWeatherApp.ViewModels
{
    public partial class WeatherViewModel : BaseViewModel
    {
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();
        IWebService? web => Startup.ServiceProvider.GetService<IWebService>();

        [ObservableProperty]
        WeatherForecast weather;

        [ObservableProperty]
        int numDays;

        [ObservableProperty]
        bool quality;

        [ObservableProperty]
        bool withAlerts;

        [ObservableProperty]
        LocationModel? location;

        [ObservableProperty]
        Current? current;

        [ObservableProperty]
        Forecast? forecast;

        [ObservableProperty]
        Alerts? alerts;

        [ObservableProperty]
        AirQuality? airQuality;

        [ObservableProperty]
        bool hasAirQuality;

        [ObservableProperty]
        bool hasAlerts;

        public async Task Init()
        {
            var currentLoc = await GetCurrentLocation();
            if (currentLoc != null)
            {
                NumDays = userSettings.LoadSetting<int>("days", SettingType.Int);
                Quality = userSettings.LoadSetting<bool>("air", SettingType.Bool);
                WithAlerts = userSettings.LoadSetting<bool>("alerts", SettingType.Bool);

                if (IsConnected)
                {
                    Weather = await web.GetWeather(currentLoc.Latitude, currentLoc.Longitude, NumDays, Quality, WithAlerts);
                    if (Weather != null)
                    {
                        if (Weather.Location != null)
                            Location = Weather.Location;
                        if (Weather.Current != null)
                            Current = Weather.Current;
                        if (Weather.Alerts != null)
                        {
                            Alerts = Weather.Alerts;
                            HasAlerts = true;
                        }
                        if (Weather.Forecast != null)
                            Forecast = Weather.Forecast;
                    }
                    else
                        await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(Languages.Resources.Eror_NoWeather_Title, Languages.Resources.Error_NoWeather_Message), true);
                }
                else
                {
                    await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(Languages.Resources.Error_ConnectTitle, Languages.Resources.Error_ConnectMessage), true);
                }
            }
            else
                await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(Languages.Resources.Error_LocationTitle, Languages.Resources.Error_LocationNull), true);

        }
    }
}
