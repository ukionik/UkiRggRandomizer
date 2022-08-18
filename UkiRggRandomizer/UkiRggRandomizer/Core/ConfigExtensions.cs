using System;
using System.Linq;
using System.Reflection;
using GenHTTP.Modules.Layouting.Provider;
using GenHTTP.Modules.Webservices;
using Microsoft.Extensions.DependencyInjection;

namespace UkiRggRandomizer.Core;

public static class ConfigExtensions
{
    private static readonly Assembly _assembly = typeof(ConfigExtensions).Assembly;
    
    public static IServiceCollection AddByAttribute<T>(this IServiceCollection services)
        where T : Attribute
    {
        (from type in _assembly.GetTypes()
                where type.IsDefined(typeof(T), false)
                select type).ToList()
            .ForEach(type =>
            {
                var interfaceName = $"I{type.Name}";
                var iface = type.GetInterface(interfaceName)!;
                services.AddSingleton(iface, type);
            });

        return services;
    }

    public static LayoutBuilder AddControllers(this LayoutBuilder builder, IServiceProvider diProvider)
    {
        var attributeType = typeof(ResourceAttribute);
        
        (from type in _assembly.GetTypes()
                where type.IsDefined(attributeType, false)
                    select type).ToList()
            .ForEach(resourceType =>
            {
                var controllerName = resourceType.Name.Replace("Resource", "").ToKebabCase();
                var constructorInfo = resourceType.GetConstructors()[0];
                var instance = Activator.CreateInstance(resourceType, constructorInfo.GetParameters()
                    .Select(parameterInfo => diProvider.GetService(parameterInfo.ParameterType))
                    .Cast<object>().ToArray());
                builder.AddService(controllerName, instance);                
            });

        return builder;
    }
}