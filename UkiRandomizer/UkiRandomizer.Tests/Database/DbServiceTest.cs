using UkiRandomizer.Service;
using UkiRandomizer.Tests.Core;
using static NUnit.Framework.Assert;

namespace UkiRandomizer.Tests.Database;

public class DbServiceTest
{
    private DbService _dbService;

    private List<TestEntity> _entities = new()
    {
        new TestEntity(1, "Nes"),
        new TestEntity(2, "Sega"),
        new TestEntity(3, "SNES")
    };

    [SetUp]
    public void SetUp()
    {
        _dbService = new DbService();
    }

    [Test]
    public void DbTest()
    {
        _dbService.ExecuteQuery(db =>
        {
            var col = db.GetCollection<TestEntity>();
            col.DeleteAll();
            col.Insert(_entities);
        });

        var dbEntities = _dbService.GetList(db =>
        {
            var col = db.GetCollection<TestEntity>();
            return col.Query()
                .Where(x => x.Id > 1)
                .ToList();
        });

        That(dbEntities.Count, Is.EqualTo(2));
        That(dbEntities[0].Name, Is.EqualTo("Sega"));
        That(dbEntities[1].Name, Is.EqualTo("SNES"));
    }
    
    [Test]
    public void DbGetTest()
    {
        var dbEntities = _dbService.GetList(db =>
        {
            var col = db.GetCollection<TestEntity>();
            return col.Query()
                .Where(x => x.Id > 1)
                .ToList();
        });

        That(dbEntities.Count, Is.EqualTo(2));
        That(dbEntities[0].Name, Is.EqualTo("Sega"));
        That(dbEntities[1].Name, Is.EqualTo("SNES"));
    }
}