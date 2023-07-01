using System;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Enums;

namespace UkiRandomizer.Model.Entity;

public class Game : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PlatformId { get; set; }
    public int GenreId { get; set; }
    public DateTime UsReleaseDate { get; set; }
    public DateTime EuReleaseDate { get; set; }
    public DateTime JpReleaseDate { get; set; }
    public DateTime BrReleaseDate { get; set; }
    public GameCheckedStatus CheckedStatus { get; set; }
    public string Comment { get; set; }
    public bool HasFanTranslation { get; set; }
    public bool HasAdditionalDevice { get; set; }
}