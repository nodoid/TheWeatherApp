using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;
using TheWeatherApp.Views.Popups;

namespace TheWeatherApp.ViewModels
{
    public partial class TidesViewModel : BaseViewModel
    {
        IWebService? web => Startup.ServiceProvider.GetService<IWebService>();
        IMessenger? messenger => Startup.ServiceProvider.GetService<IMessenger>();
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();

        [ObservableProperty]
        int numDays;

        [ObservableProperty]
        static TideRoot tide;

        [ObservableProperty]
        Forecast? forecasted;

        [ObservableProperty]
        LocationModel? locations;

        [ObservableProperty]
        bool isRefreshing;
        
        [ObservableProperty] 
        bool refreshScreen;

        [RelayCommand]
        public async Task RefreshData()
        {
            await Init();
        }

        bool isInRefresh;
        public TidesViewModel()
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
            if (!isInRefresh)
            {
                isInRefresh = true;
                var currentLoc = await GetCurrentLocation();
                if (currentLoc != null)
                {
                    NumDays = userSettings.LoadSetting<int>("days", SettingType.Int);

                    var dt = DateTime.Parse(userSettings.LoadSetting<string>("used", SettingType.String));
                    var calc = DateTime.Now.Subtract(dt).TotalMinutes;
                    if (calc >= 15 || calc <= 1 || Forecasted == null)
                    {
                        if (IsConnected)
                        {
                            IsRefreshing = true;
                            Tide = await web.GetTides(currentLoc.Latitude, currentLoc.Longitude, NumDays);
                            if (Tide != null)
                            {
                                userSettings.SaveSetting("used", DateTime.Now.ToString(), SettingType.String);
                                if (Tide.Location != null)
                                    Locations = Tide.Location;
                                if (Tide.Forecast != null)
                                    Forecasted = Tide.Forecast;
                                IsRefreshing = false;
                                RefreshScreen = true;
                            }
                            else
                            {
                                IsRefreshing = false;
                                await Mopups.Services.MopupService.Instance.PushAsync(
                                    new ErrorMessagePopupPage(Languages.Resources.Error_Tides_Title,
                                        Languages.Resources.Error_Tides_NoData), true);
                            }
                        }
                        else
                        {
                            await Mopups.Services.MopupService.Instance.PushAsync(
                                new ErrorMessagePopupPage(Languages.Resources.Error_ConnectTitle,
                                    Languages.Resources.Error_ConnectMessage), true);
                        }
                    }
                }
                else
                    await Mopups.Services.MopupService.Instance.PushAsync(
                        new ErrorMessagePopupPage(Languages.Resources.Error_LocationTitle,
                            Languages.Resources.Error_LocationNull), true);

                RefreshScreen = false;
                isInRefresh = false;
            }
        }
    }
}
