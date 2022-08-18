﻿using Microsoft.Extensions.DependencyInjection;
using UkiRggRandomizer.Repositories;
using UkiRggRandomizer.Service;

namespace UkiRggRandomizer.Configuration;

public static class DIConfig
{
    public static ServiceProvider Init()
    {
        var services = ConfigureServices();
        return services.BuildServiceProvider();
    }

    private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IHelloService, HelloService>();
        services.AddSingleton<IWheelService, WheelService>();
        services.AddSingleton<IGlobalRepository, GlobalRepository>();
        services.AddSingleton<ISoundService, SoundService>();

        return services;
    }
}