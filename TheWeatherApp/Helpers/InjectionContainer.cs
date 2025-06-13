using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Interfaces;
using TheWeatherApp.PlatformServices;
using TheWeatherApp.Services;

namespace TheWeatherApp.Helpers;

public static class InjectionContainer
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        var i = new ServiceCollection()
            .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            .AddSingleton<IUserSettings, UserSettings>()
            .AddSingleton<IWebService,WebService>();
            
        services = i;
        return services;
    }
}