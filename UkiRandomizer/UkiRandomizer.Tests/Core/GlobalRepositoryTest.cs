using UkiRandomizer.Repositories;

namespace UkiRandomizer.Tests.Core;

public class GlobalRepositoryTest : IGlobalRepository
{
    public string AppPath { get; set; } = @"d:\Projects\UkiRggRandomizer\UkiRggRandomizer\UkiRggRandomizer\";
    public string ResourcePath => Path.Combine(AppPath, "Resources");
    public string SoundPath => Path.Combine(ResourcePath, "Sounds");
    public string SheetConfigPath => Path.Combine(AppPath, "sheet.json");
    public string DbPath => "data.db";
}