using TheWeatherApp.ViewModels;

namespace TheWeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup.ServiceProvider.GetService<BaseViewModel>().FirstRun();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}