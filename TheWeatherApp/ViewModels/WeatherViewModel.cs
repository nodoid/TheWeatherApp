using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;
using TheWeatherApp.Views.Popups;

namespace TheWeatherApp.ViewModels
{
    public partial class WeatherViewModel : BaseViewModel
    {
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();
        IMessenger? messenger => Startup.ServiceProvider.GetService<IMessenger>();
        IWebService? web => Startup.ServiceProvider.GetService<IWebService>();

        [ObservableProperty] WeatherForecast weather;

        [ObservableProperty] int numDays;

        [ObservableProperty] bool quality;

        [ObservableProperty] bool withAlerts;

        [ObservableProperty] LocationModel? location;

        [ObservableProperty] Current? current;

        [ObservableProperty] Forecast? forecast;

        [ObservableProperty] Alerts? alerts;

        [ObservableProperty] AirQuality? airQuality;

        [ObservableProperty] bool hasAirQuality;

        [ObservableProperty] bool hasAlerts;

        [ObservableProperty] bool isRefreshing;

        [ObservableProperty] bool refreshScreen;

        [RelayCommand]
        async Task RefreshData()
        {
            IsRefreshing = true;
            await Init();
            IsRefreshing = false;
        }

        public WeatherViewModel()
        {
            messenger.Register<BooleanMessage>(this, (n, t) =>
            {
                if (t.Message == "InitData")
                {
                    Task.Run(Init);
                }
            });
        }

        
        public async Task Init()
        {
            var currentLoc = await GetCurrentLocation();
            if (currentLoc != null)
            {
                NumDays = userSettings.LoadSetting<int>("days", SettingType.Int);
                Quality = userSettings.LoadSetting<bool>("air", SettingType.Bool);
                WithAlerts = userSettings.LoadSetting<bool>("alerts", SettingType.Bool);

                var dt = DateTime.Parse(userSettings.LoadSetting<string>("used", SettingType.String));
                if (DateTime.Now.Subtract(dt).TotalMinutes >= 15 || DateTime.Now.Subtract(dt).TotalMinutes <= 1)
                {
                    if (IsConnected)
                    {
                        IsRefreshing = true;
                        Weather = await web.GetWeather(currentLoc.Latitude, currentLoc.Longitude, NumDays, Quality,
                            WithAlerts);
                        if (Weather != null)
                        {
                            userSettings.SaveSetting("used", DateTime.Now.ToString(), SettingType.String);
                            if (Weather.Location != null)
                                Location = Weather.Location;
                            if (Weather.Current != null)
                                Current = Weather.Current;
                            if (Weather.Alerts != null)
                            {
                                Alerts = Weather.Alerts;
                                HasAlerts = Alerts.Alert.Count > 0;
                            }
                            if (Weather.Forecast != null)
                                Forecast = Weather.Forecast;
                            RefreshScreen = true;
                        }
                        else
                        {
                            IsRefreshing = false;
                            await Mopups.Services.MopupService.Instance.PushAsync(
                                new ErrorMessagePopupPage(Languages.Resources.Eror_NoWeather_Title,
                                    Languages.Resources.Error_NoWeather_Message), true);
                        }
                    }
                    else
                    {
                        IsRefreshing = false;
                        await Mopups.Services.MopupService.Instance.PushAsync(
                            new ErrorMessagePopupPage(Languages.Resources.Error_ConnectTitle,
                                Languages.Resources.Error_ConnectMessage), true);
                    }
                }
                else
                {
                    IsRefreshing = false;
                    await Mopups.Services.MopupService.Instance.PushAsync(
                        new ErrorMessagePopupPage(Languages.Resources.Error_LocationTitle,
                            Languages.Resources.Error_LocationNull), true);
                }
                RefreshScreen = true;
            }
        }
    }
}
