using Microsoft.Extensions.DependencyInjection;
using UkiRggRandomizer.Service;

namespace UkiRggRandomizer.Configuration;

public static class DIConfiguration
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

        return services;
    }
}