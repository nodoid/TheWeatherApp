using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Models;

namespace TheWeatherApp.ViewModels
{
    public partial class ErrorsViewModel : BaseViewModel
    {
        readonly IMessenger messenger;

        public ErrorsViewModel()
        {
            messenger = (IMessenger)Startup.ServiceProvider.GetService(typeof(IMessenger));
        }

        [ObservableProperty]
        string errorTitle;

        [ObservableProperty]
        string errorText;

        [RelayCommand]
        public void ReturnToCaller()
        {
            messenger.Send(new BooleanMessage { BoolValue = true, Message = "FromError" });
        }
    }
}
