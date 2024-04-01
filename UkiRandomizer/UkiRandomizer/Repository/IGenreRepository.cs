using UkiRandomizer.Core.Repository;
using UkiRandomizer.Model.Entity;

namespace UkiRandomizer.Repository;

public interface IGenreRepository : ICollectionRepositoryAsync<int, Genre>
{
    
}