using System;

namespace UkiRandomizer.Model.Entity;

public class Platform
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public DateTime ReleaseDate { get; set; }
}