using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;
using TheWeatherApp.Views.Popups;

namespace TheWeatherApp.ViewModels
{
    public partial class TidesViewModel : BaseViewModel
    {
        IWebService? web => Startup.ServiceProvider.GetService<IWebService>();
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();

        [ObservableProperty]
        int numDays;

        [ObservableProperty]
        TideRoot tide;

        [ObservableProperty]
        Forecast? forecasted;

        [ObservableProperty]
        LocationModel? locations;

        public async Task Init()
        {
            var currentLoc = await GetCurrentLocation();
            if (currentLoc != null)
            {
                NumDays = userSettings.LoadSetting<int>("days", SettingType.Int);

                if (IsConnected)
                {
                    Tide = await web.GetTides(currentLoc.Latitude, currentLoc.Longitude, NumDays);
                    if (Tide != null)
                    {
                        if (Tide.Location != null)
                            Locations = Tide.Location;
                        if (Tide.Forecast != null)
                            Forecasted = Tide.Forecast;
                    }
                    else
                        await Mopups.Services.MopupService.Instance.PushAsync(new ErrorMessagePopupPage(Languages.Resources.Error_Tides_Title, Languages.Resources.Error_Tides_NoData), true);
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
