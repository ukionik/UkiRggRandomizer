using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using UkiRggRandomizer.Core;
using UkiRggRandomizer.Repositories;

namespace UkiRggRandomizer.Service;

[Service]
public class DbService : IDbService
{
    private readonly IGlobalRepository _globalRepository;

    public DbService(IGlobalRepository globalRepository)
    {
        _globalRepository = globalRepository;
    }

    public List<T> GetList<T>(Func<LiteDatabase, List<T>> dbQuery)
    {
        using var db = new LiteDatabase(_globalRepository.DbPath);
        return dbQuery.Invoke(db);
    }

    public void ExecuteQuery(Action<LiteDatabase> dbQuery)
    {
        using var db = new LiteDatabase(_globalRepository.DbPath);
        dbQuery.Invoke(db);
    }
}