using System;
using System.IO;
using UkiRandomizer.Core;

namespace UkiRandomizer.Repository;

[Repository]
public class GlobalRepository : IGlobalRepository
{
    public Uri HostUrl { get; } = new("http://localhost:18234");
    public string AppPath { get; set; } = Directory.GetParent(typeof(GlobalRepository).Assembly.Location).FullName;

    public string ResourcePath => Path.Combine(AppPath, "Resources");
    public string SoundPath => Path.Combine(ResourcePath, "Sounds");
    public string DbPath => Path.Combine(AppPath, "data.db");
}