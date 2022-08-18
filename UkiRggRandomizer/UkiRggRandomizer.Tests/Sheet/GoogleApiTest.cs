using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using UkiRggRandomizer.Model.Sheet;
using UkiRggRandomizer.Tests.Core;

namespace UkiRggRandomizer.Tests;

public class GoogleApiTest
{
    private GlobalRepositoryTest _globalRepository;

    [SetUp]
    public void SetUp()
    {
        _globalRepository = new GlobalRepositoryTest();
    }

    [Test]
    public void SpreadSheetTest()
    {
        var config = SheetConfig.Parse(_globalRepository.SheetConfigPath);
        
        var service = new SheetsService(new BaseClientService.Initializer
        {
            ApiKey = config.Key
        });

        var sheetId = config.SheetId;
        var range = "NES!A:L";
        var request =
            service.Spreadsheets.Values.Get(sheetId, range);
        var response = request.Execute();
        var values = response.Values;
        foreach (var row in values) Console.WriteLine($"{row[0]} | {row[1]}");
    }
}