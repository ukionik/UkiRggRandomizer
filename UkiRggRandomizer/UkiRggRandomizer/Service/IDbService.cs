using System;
using System.Collections.Generic;
using LiteDB;

namespace UkiRggRandomizer.Service;

public interface IDbService
{
    List<T> GetList<T>(Func<LiteDatabase, List<T>> dbQuery);
    void ExecuteQuery(Action<LiteDatabase> dbQuery);
}