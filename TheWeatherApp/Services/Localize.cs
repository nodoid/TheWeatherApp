using TheWeatherApp.Interfaces;
using System.Globalization;
#if IOS
using Foundation;
#endif

namespace FTrack4.PlatformServices
{
    public class Localize : ILocalize
    {
        public void SetLocale()
        {
#if ANDROID
            var androidLocale = Java.Util.Locale.Default;
            var netLocale = androidLocale.ToString().Replace("_", "-");
            var ci = new CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
#else
            var ci = new CultureInfo(GetCurrent());
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
#endif
        }

        public string GetCurrent()
        {
#if ANDROID
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.Language.Replace("_", "-");
            var netLocale = androidLocale.ToString().Replace("_", "-");

            var ci = new System.Globalization.CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            return netLocale;
#else
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;  
            var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            var netLanguage = iosLanguageAuto.Replace("_", "-");

            const string defaultCulture = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                netLanguage = pref.Replace("_", "-");
                try
                {
                    var ci = CultureInfo.CreateSpecificCulture(netLanguage);
                    netLanguage = ci.Name;
                }
                catch
                {
                    netLanguage = defaultCulture;
                }
            }
            else
            {
                netLanguage = defaultCulture;
            }

            return netLanguage;
#endif
        }
    }
}
