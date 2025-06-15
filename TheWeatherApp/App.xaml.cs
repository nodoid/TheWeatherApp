using System.Globalization;
using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Models;
using TheWeatherApp.ViewModels;

namespace TheWeatherApp
{
    public partial class App : Application
    {
        public static IServiceProvider Service { get; set; }
        public bool IsConnected { get; private set; }
        public static App Self { get; private set; }
        public static Size ScreenSize { get; private set; }
        
        bool isStarted { get; set; } = false;
        public App()
        {
            App.Self = this;

            Service = Startup.Init();

            ScreenSize = new Size(DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height);
            InitializeComponent();
            
            var connect = (Connectivity.NetworkAccess == NetworkAccess.Internet) || (Connectivity.NetworkAccess == NetworkAccess.Local);

            Service.GetService<BaseViewModel>().IsConnected = IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.TabbedView());
        }
        
        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var connect = Connectivity.NetworkAccess == NetworkAccess.Internet;

            Service.GetService<BaseViewModel>().IsConnected = IsConnected = connect;
        }
        
        protected override void OnStart()
        {
            if (!isStarted)
            {
                isStarted = true;
                var netLanguage = Service.GetService<ILocalize>().GetCurrent();
                Languages.Resources.Culture = new CultureInfo(netLanguage);
                Service.GetService<ILocalize>().SetLocale();
                
                Startup.ServiceProvider.GetService<BaseViewModel>().FirstRun();
                WeakReferenceMessenger.Default.Send(new BooleanMessage { BoolValue = true, Message = "InitData" });
            }
        }
    }
}