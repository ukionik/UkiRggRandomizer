using System.IO;
using Newtonsoft.Json;

namespace UkiRggRandomizer.Model.Sheet;

public static class SheetConfig
{
    public static SheetConfigData Parse(string sheetConfigPath)
    {
        using var reader = new StreamReader(sheetConfigPath);
        var json = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<SheetConfigData>(json)!;
    }
}