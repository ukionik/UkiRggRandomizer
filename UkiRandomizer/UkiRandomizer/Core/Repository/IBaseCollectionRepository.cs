using System.Collections.Generic;

namespace UkiRandomizer.Core.Repository;

public interface IBaseCollectionRepository<TKey, TEntity>
    where TEntity : IEntity<TKey>
{
    List<TEntity> Data { get; }
}