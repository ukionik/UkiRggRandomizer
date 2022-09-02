namespace UkiRandomizer.Core.Repository;

public interface ICrudCollectionRepository<TKey, TEntity> : ICollectionRepository<TKey, TEntity>
    where TEntity : IEntity<TKey>
{
}