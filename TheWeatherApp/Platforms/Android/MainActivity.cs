using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace TheWeatherApp
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public static Activity? Active { get; private set; }

        public static ISharedPreferences? Prefs { get; set; }

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            Active = this;
            Prefs = Active.GetSharedPreferences("weather", FileCreationMode.Private);

            base.OnCreate(savedInstanceState);
            RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}
