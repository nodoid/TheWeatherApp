using Foundation;
using UIKit;

namespace TheWeatherApp
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        public static AppDelegate Self { get; private set; }
        public NSUserDefaults UserDefaults { get; private set; }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppDelegate.Self = this;
            UserDefaults = new NSUserDefaults("group.uk.co.all-the-johnsons.theweatherapp");

            return base.FinishedLaunching(app, options);
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
