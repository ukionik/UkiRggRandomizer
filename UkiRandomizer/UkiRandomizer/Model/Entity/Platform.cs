using System;
using UkiRandomizer.Core;

namespace UkiRandomizer.Model.Entity;

public class Platform : IEntity<int>
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public DateTime ReleaseDate { get; set; }
}