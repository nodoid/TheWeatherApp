﻿using TheWeatherApp.Helpers;

namespace TheWeatherApp;

public static class Startup
{
    public static IServiceProvider ServiceProvider { get; set; }

    public static IServiceProvider Init()
    {
        var provider = new ServiceCollection().ConfigureServices().ConfigureViewModels().BuildServiceProvider();

        ServiceProvider = provider;

        return provider;
    }
}