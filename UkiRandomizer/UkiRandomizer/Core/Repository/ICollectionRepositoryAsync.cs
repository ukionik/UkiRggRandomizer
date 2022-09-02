using System.Threading.Tasks;

namespace UkiRandomizer.Core.Repository;

public interface ICollectionRepositoryAsync<TKey, TEntity> : IBaseCollectionRepository<TKey, TEntity>
    where TEntity : IEntity<TKey>
{
    Task LoadAsync();
}