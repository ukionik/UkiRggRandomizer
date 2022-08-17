using System.IO;

namespace UkiRggRandomizer.Repositories;

public class GlobalRepository : IGlobalRepository
{
    public string AppPath { get; set; } = Directory.GetParent(typeof(GlobalRepository).Assembly.Location).FullName;

    public string ResourcePath => Path.Combine(AppPath, "Resources");
    public string SoundPath => Path.Combine(ResourcePath, "Sounds");
}