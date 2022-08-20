namespace UkiRandomizer.Tests.Database;

public class TestEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TestEntity()
    {
    }

    public TestEntity(int id, string name)
    {
        Id = id;
        Name = name;
    }
}