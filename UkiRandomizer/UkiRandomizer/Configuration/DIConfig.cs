using Microsoft.Extensions.DependencyInjection;
using UkiRandomizer.Core;

namespace UkiRandomizer.Configuration;

public static class DIConfig
{
    public static ServiceProvider Init()
    {
        var services = ConfigureServices();
        return services.BuildServiceProvider();
    }

    private static IServiceCollection ConfigureServices()
    {
        return new ServiceCollection()
            .AddByAttribute<ServiceAttribute>()
            .AddByAttribute<RepositoryAttribute>();
    }
}