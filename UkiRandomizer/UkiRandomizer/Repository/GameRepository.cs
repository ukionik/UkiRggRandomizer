using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Entity;
using UkiRandomizer.Service;

namespace UkiRandomizer.Repository;

[Repository]
public class GameRepository : IGameRepository
{
    private readonly IDbService _dbService;
    private readonly PlatformRepository _platformRepository;
    private readonly ISheetService _sheetService;

    public GameRepository(ISheetService sheetService
        , IDbService dbService
        , PlatformRepository platformRepository)
    {
        _sheetService = sheetService;
        _dbService = dbService;
        _platformRepository = platformRepository;
    }

    public List<Game> Data { get; private set; }

    public Task LoadAsync()
    {
        var platforms = _platformRepository.Data;

        foreach (var platform in platforms)
        {
            
        }

        return null;
    }
}