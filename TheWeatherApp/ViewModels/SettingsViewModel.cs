using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;

namespace TheWeatherApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();

        [ObservableProperty] int numDays;

        [ObservableProperty] bool alerts;

        [ObservableProperty] bool air;

        [RelayCommand]
        public void SaveSettings()
        {
            userSettings.SaveSetting("days", value:NumDays, SettingType.Int);
            userSettings.SaveSetting("alerts", Alerts, SettingType.Bool);
            userSettings.SaveSetting("alerts", Air, SettingType.Bool);
        }

        public void Init()
        {
            NumDays = userSettings.LoadSetting<int>("days", SettingType.Int);
            Alerts = userSettings.LoadSetting<bool>("alerts", SettingType.Bool);
            Air = userSettings.LoadSetting<bool>("air", SettingType.Bool);
        }
    }
}
