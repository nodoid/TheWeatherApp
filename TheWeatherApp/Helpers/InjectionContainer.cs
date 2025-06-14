using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Interfaces;
using TheWeatherApp.Services;
using TheWeatherApp.ViewModels;

namespace TheWeatherApp.Helpers;

public static class InjectionContainer
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        var i = new ServiceCollection()
            .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            .AddSingleton<IUserSettings, UserSettings>()
            .AddSingleton<ILocalize, Localize>()
            .AddSingleton<IWebService,WebService>();
            
        services = i;
        return services;
    }
    
    [Obsolete]
    public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
    {
        services.AddTransient<BaseViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<TidesViewModel>();
        services.AddTransient<WeatherViewModel>();
        services.AddTransient<ErrorsViewModel>();

        return services;
    }
}