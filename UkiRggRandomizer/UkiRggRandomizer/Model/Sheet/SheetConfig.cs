using System;
using System.IO;
using Newtonsoft.Json;

namespace UkiRggRandomizer.Model.Sheet;

public static class SheetConfig
{
    public static SheetConfigData Parse()
    {
        var assembly = typeof(SheetConfig).Assembly;
        var resourceStream = assembly.GetManifestResourceStream("UkiRggRandomizer.sheet.json");
        using var reader = new StreamReader(resourceStream);
        var json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<SheetConfigData>(json)!;
    }
}