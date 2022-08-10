using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GenHTTP.Modules.Layouting.Provider;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Controller;

namespace UkiRggRandomizer.Core;

public static class Extensions
{
    public static LayoutBuilder AddController<T>(this LayoutBuilder builder, IServiceProvider diProvider)
        where T : IResource
    {
        var resourceType = typeof(T);
        var controllerName = resourceType.Name.Replace("Resource", "").ToKebabCase();
        var constructorInfo = resourceType.GetConstructors()[0];
        var instance = Activator.CreateInstance(resourceType, constructorInfo.GetParameters()
            .Select(parameterInfo => diProvider.GetService(parameterInfo.ParameterType))
            .Cast<object>().ToArray());
        builder.AddService(controllerName, instance);

        return builder;
    }

    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return Regex.Replace(
                value,
                "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                "-$1",
                RegexOptions.Compiled)
            .Trim()
            .ToLower();
    }
    
    public static void Shuffle<T>(this IList<T> list, Random r)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = r.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
}