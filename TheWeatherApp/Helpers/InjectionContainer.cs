using CommunityToolkit.Mvvm.Messaging;
using TheWeatherApp.Database;
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
            .AddSingleton<IRepository, SqLiteRepository>();
            
        services = i;
        return services;
    }
}