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
    private readonly SheetsService _service;
    private readonly string _sheetId;

    public SheetService(IGlobalRepository globalRepository)
    {
        var config = SheetConfig.Parse(globalRepository.SheetConfigPath);
        _sheetId = config.SheetId;
        _service = new SheetsService(new BaseClientService.Initializer
        {
            ApiKey = config.Key
        });
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
        var request = _service.Spreadsheets.Values.Get(_sheetId, range);
        return await request.ExecuteAsync();
    }
}