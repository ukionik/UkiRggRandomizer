using System.Collections.Generic;
using System.Threading.Tasks;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Entity;
using UkiRandomizer.Service;

namespace UkiRandomizer.Repositories;

[Repository]
public class PlatformRepository : IPlatformRepository
{
    private readonly ISheetService _sheetService;
    private readonly IDbService _dbService;

    public PlatformRepository(ISheetService sheetService
    , IDbService dbService)
    {
        _sheetService = sheetService;
        _dbService = dbService;
    }

    public List<Platform> Data { get; private set; }
    
    public async Task LoadAsync()
    {
        var platforms = _dbService.GetList(db => db.GetCollection<Platform>().Query().ToList());
        if (platforms.Count == 0)
        {
            platforms = await _sheetService.LoadPlatformsAsync();
            _dbService.ExecuteQuery(db =>
            {
                db.GetCollection<Platform>().Insert(platforms);
            });
        }

        Data = platforms;
    }
}