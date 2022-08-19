using System.IO;
using Newtonsoft.Json;

namespace UkiRggRandomizer.Core;

public static class ResourceManager
{
    public static T GetJsonFile<T>(string fileName)
    {
        using var resourceStream =typeof(ResourceManager).Assembly.GetManifestResourceStream($"UkiRggRandomizer.{fileName}");
        using var reader = new StreamReader(resourceStream);
        var json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<T>(json)!;
    }
}