using UkiRandomizer.Core;

namespace UkiRandomizer.Model.Entity;

public class Profile : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
}