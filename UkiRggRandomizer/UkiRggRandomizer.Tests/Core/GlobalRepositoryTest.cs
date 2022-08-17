using UkiRggRandomizer.Repositories;

namespace UkiRggRandomizer.Tests.Core;

public class GlobalRepositoryTest : IGlobalRepository
{
    public string AppPath { get; set; } = @"d:\Projects\UkiRggRandomizer\UkiRggRandomizer\UkiRggRandomizer\";
    public string ResourcePath => Path.Combine(AppPath, "Resources");
    public string SoundPath => Path.Combine(ResourcePath, "Sounds");
    public string SheetConfigPath => Path.Combine(AppPath, "sheet.json");
}