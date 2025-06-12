using TheWeatherApp.Enums;

namespace TheWeatherApp.Interfaces
{
    public interface IUserSettings
    {
        void SetPrefName(string name);

        void SaveSetting<T>(string name, T value, SettingType setting);

        T LoadSetting<T>(string name, SettingType setting);

        void RemoveSetting(string name);

        void RemoveSettings(List<string> names);
        void Clear();
    }
}
