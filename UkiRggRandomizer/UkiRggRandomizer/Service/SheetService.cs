using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UkiRggRandomizer.Core;
using UkiRggRandomizer.Model.Entity;
using UkiRggRandomizer.Model.Sheet;
using UkiRggRandomizer.Repositories;

namespace UkiRggRandomizer.Service;

[Service]
public class SheetService : ISheetService
{
    private static readonly SheetConfigData Config;
    private static readonly string SheetId;

    private readonly Lazy<SheetsService> _service = new(() => new SheetsService(new BaseClientService.Initializer
    {
        ApiKey = Config.Key
    }));

    static SheetService()
    {
        Config = ResourceManager.GetJsonFile<SheetConfigData>("sheet.json");
        SheetId = Config.SheetId;        
    }

    public async Task<List<Platform>> LoadPlatformsAsync()
    {
        var range = "Platforms!A:C";
        var result = GetRangeAsync(range).Result;
        var platforms = result.Values
            .Select(row => new Platform
            {
                ShortName = row[0].ToString(), 
                FullName = row[1].ToString(),
                ReleaseDate = DateTime.Parse(row[2].ToString(), new CultureInfo("ru-RU")) 
            }).ToList();
        return await Task.FromResult(platforms);
    }

    private async Task<ValueRange> GetRangeAsync(string range)
    {
        var request = _service.Value.Spreadsheets.Values.Get(SheetId, range);
        return await request.ExecuteAsync();
    }
}