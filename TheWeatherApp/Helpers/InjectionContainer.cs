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
            .AddTransient<PDFReaderViewModel>()
            .AddSingleton<IListAssets, ListResAssets>()
            .AddSingleton<IFormFilename, CreatePlatformUrl>()
            .AddSingleton<IRepository, SqLiteRepository>();
            
        services = i;
        return services;
    }
}