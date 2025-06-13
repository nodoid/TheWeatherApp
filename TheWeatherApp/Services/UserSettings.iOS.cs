#if IOS
using Foundation;
using TheWeatherApp.Enums;
using TheWeatherApp.Interfaces;
using Newtonsoft.Json;

namespace TheWeatherApp.PlatformServices
{
    public class UserSettings : IUserSettings
    {
        public void SaveSetting<T>(string name, T value, SettingType setting)
        {
            dynamic insertValue = null;
            switch (setting)
            {
                case SettingType.String:
                    insertValue = (NSString)(string)(object)value;
                    break;
                case SettingType.Bool:
                    insertValue = (NSNumber)(bool)(object)value;
                    break;
                case SettingType.Long:
                    insertValue = (NSNumber)(long)(object)value;
                    break;
                case SettingType.Float:
                    insertValue = (NSNumber)(float)(object)value;
                    break;
                case SettingType.Int:
                    insertValue = (NSNumber)(int)(object)value;
                    break;
            }

            AppDelegate.Self.UserDefaults[name] = insertValue;
        }

        public void SaveSetting(string name, List<string> vals) => SaveSetting(name, JsonConvert.SerializeObject(vals), SettingType.String);

        public T LoadSetting<T>(string name, SettingType setting)
        {
            var value = AppDelegate.Self.UserDefaults[name];

            NSNumber val = null;

            dynamic returnValue = null;

            if (setting != SettingType.String)
                val = (NSNumber)value;

            if (val == null && setting != SettingType.String)
                return default(T);

            switch (setting)
            {
                case SettingType.String:
                    returnValue = value != null ? value.ToString() : string.Empty;
                    break;
                case SettingType.Bool:
                    returnValue = val.BoolValue;
                    break;
                case SettingType.Float:
                    returnValue = val.FloatValue;
                    break;
                case SettingType.Int:
                    returnValue = val.Int32Value;
                    break;
                case SettingType.Long:
                    returnValue = val.LongValue;
                    break;
            }

            return (T)returnValue;
        }

        public List<string> LoadSetting(string name)
        {
            var rv = new List<string>();
            var serialisedVars = LoadSetting<string>(name, SettingType.String);
            if (!string.IsNullOrEmpty(serialisedVars))
                rv.AddRange(JsonConvert.DeserializeObject<List<string>>(serialisedVars));

            return rv;
        }

        public void SetPrefName(string name)
        {
            // can't be changed in iOS
        }

        public void RemoveSetting(string name)
        {
            AppDelegate.Self.UserDefaults.RemoveObject(name);
        }

        public void RemoveSettings(List<string> names)
        {
            foreach (var n in names)
                AppDelegate.Self.UserDefaults.RemoveObject(n);
        }
        public void Clear()
        {
            AppDelegate.Self.UserDefaults.RemovePersistentDomain(NSBundle.MainBundle.BundleIdentifier);
        }
    }
}
#endif
