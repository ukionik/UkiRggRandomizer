using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Entity;
using UkiRandomizer.Service;

namespace UkiRandomizer.Repository;

[Repository]
public class GenreRepository : IGenreRepository
{
    private readonly ISheetService _sheetService;
    private readonly IDbService _dbService;
    public List<Genre> Data { get; private set; }

    public GenreRepository(ISheetService sheetService
    , IDbService dbService)
    {
        _sheetService = sheetService;
        _dbService = dbService;
    }
    
    public async Task LoadAsync()
    {
        var genres = _dbService.GetList(db => db.GetCollection<Genre>().Query().ToList());
        if (genres.Count == 0)
        {
            genres = await _sheetService.LoadGenresAsync();
            _dbService.ExecuteQuery(db =>
            {
                db.GetCollection<Genre>().Insert(genres);
            });
        }

        Data = genres.OrderBy(x => x.Name).ToList();
    }
}