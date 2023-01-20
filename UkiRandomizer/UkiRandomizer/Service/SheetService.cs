using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Entity;
using UkiRandomizer.Model.Sheet;

namespace UkiRandomizer.Service;

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

    public async Task<List<Genre>> LoadGenresAsync()
    {
        var range = "Genres!A:A";
        var result = GetRangeAsync(range).Result;
        var genres = result.Values
            .Select(row => new Genre
            {
                Name = row[0].ToString()
            }).ToList();
        return await Task.FromResult(genres);
    }

    private async Task<ValueRange> GetRangeAsync(string range)
    {
        var request = _service.Value.Spreadsheets.Values.Get(SheetId, range);
        return await request.ExecuteAsync();
    }
}