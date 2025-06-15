using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;

namespace TheWeatherApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();

        [ObservableProperty]
        static bool isConnected;
        
        public void FirstRun()
        {
            if (!userSettings.LoadSetting<bool>("firstRun", SettingType.Bool))
            {
                userSettings.SaveSetting("days", 1, SettingType.Int);
                userSettings.SaveSetting("air", false, SettingType.Bool);
                userSettings.SaveSetting("alerts", false, SettingType.Bool);
                userSettings.SaveSetting("used", DateTime.Now.ToString(), SettingType.String);
                userSettings.SaveSetting("firstRun", true, SettingType.Bool);
            }
        }

        public async Task<Location?> GetCurrentLocation()
        {
            try
            {
                // Check and request location permissions
                MainThread.BeginInvokeOnMainThread(async() =>
                {
                    var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted)
                    {
                        var result = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                        if (result != PermissionStatus.Granted)
                        {
                            // Permission denied
                            return;
                        }
                    }
                });

                // Get the current location
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(2)
                });

                if (location != null)
                {
                    // Location data available
                    return location;
                }
                else
                {
                    location = await Geolocation.GetLastKnownLocationAsync();
                    // Location data not available
                    return location;
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                return null;
            }
        }
    }
}
