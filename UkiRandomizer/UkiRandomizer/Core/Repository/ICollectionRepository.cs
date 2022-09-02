using System.Collections.Generic;

namespace UkiRandomizer.Core.Repository;

public interface ICollectionRepository<TKey, TEntity> : IBaseCollectionRepository<TKey, TEntity>
    where TEntity : IEntity<TKey>
{
    void Load();
}