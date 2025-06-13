using CommunityToolkit.Mvvm.ComponentModel;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;

namespace TheWeatherApp.ViewModels
{
    public partial class SettingsViewModel : BaseViewModel
    {
        IUserSettings? userSettings => Startup.ServiceProvider.GetService<IUserSettings>();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DaysChanged))]
        int numDays;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AlertsChanged))]
        bool alerts;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AirChanged))]
        bool air;

        public void DaysChanged() => userSettings.SaveSetting("days", value:NumDays, SettingType.Int);

        public void AlertsChanged() => userSettings.SaveSetting("alerts", Alerts, SettingType.Bool);

        public void AirChanged() => userSettings.SaveSetting("alerts", Air, SettingType.Bool);

        public void Init()
        {
            NumDays = userSettings.LoadSetting<int>("days", SettingType.Int);
            Alerts = userSettings.LoadSetting<bool>("alerts", SettingType.Bool);
            Air = userSettings.LoadSetting<bool>("air", SettingType.Bool);
        }
    }
}
