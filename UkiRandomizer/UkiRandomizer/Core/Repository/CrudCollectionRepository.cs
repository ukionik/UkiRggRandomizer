using System;
using System.Collections.Generic;
using UkiRandomizer.Service;

namespace UkiRandomizer.Core.Repository;

public abstract class CrudCollectionRepository<TKey, TEntity> : ICrudCollectionRepository<TKey, TEntity> 
    where TEntity : IEntity<TKey>
{
    protected readonly IDbService DbService;

    protected CrudCollectionRepository(IDbService dbService)
    {
        DbService = dbService;
    }

    public List<TEntity> Data { get; protected set; }

    public void Load()
    {
        Data = DbService.GetList(db => db.GetCollection<TEntity>().Query().ToList());
    }
}