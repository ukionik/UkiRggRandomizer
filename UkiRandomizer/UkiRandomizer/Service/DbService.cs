using System;
using System.Collections.Generic;
using LiteDB;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Database;

namespace UkiRandomizer.Service;

[Service]
public class DbService : IDbService
{
    private readonly DbConfigData _dbConfigData;

    public DbService()
    {
        _dbConfigData = ResourceManager.GetJsonFile<DbConfigData>("db-config.json");
    }

    public List<T> GetList<T>(Func<LiteDatabase, List<T>> dbQuery)
    {
        using var db = new LiteDatabase(_dbConfigData.ConnectionString);
        return dbQuery.Invoke(db);
    }

    public void ExecuteQuery(Action<LiteDatabase> dbQuery)
    {
        using var db = new LiteDatabase(_dbConfigData.ConnectionString);
        dbQuery.Invoke(db);
    }
}