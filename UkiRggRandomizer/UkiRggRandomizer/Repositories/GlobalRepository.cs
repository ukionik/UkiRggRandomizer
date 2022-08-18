using System.IO;
using UkiRggRandomizer.Core;

namespace UkiRggRandomizer.Repositories;

[Repository]
public class GlobalRepository : IGlobalRepository
{
    public string AppPath { get; set; } = Directory.GetParent(typeof(GlobalRepository).Assembly.Location).FullName;

    public string ResourcePath => Path.Combine(AppPath, "Resources");
    public string SoundPath => Path.Combine(ResourcePath, "Sounds");
    public string SheetConfigPath => Path.Combine(AppPath, "sheet.json");
    public string DbPath => Path.Combine(AppPath, "data.db");
}