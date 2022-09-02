using UkiRandomizer.Core.Repository;
using UkiRandomizer.Model.Entity;

namespace UkiRandomizer.Repository;

public interface IProfileRepository : ICrudCollectionRepository<int, Profile>
{
    void CreateDefaultIfNotExists();
}