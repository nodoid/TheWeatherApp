using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;

namespace TheWeatherApp.Services;

#if NET9_0
public class UserSettings : IUserSettings
{
    public void SetPrefName(string name)
    {
    }

    public void SaveSetting<T>(string name, T value, SettingType setting)
    {
    }

    public T LoadSetting<T>(string name, SettingType setting)
    {
       return default(T);
    }

    public void RemoveSetting(string name)
    {
    }

    public void RemoveSettings(List<string> names)
    {
    }

    public void Clear()
    {
    }
}
#endif