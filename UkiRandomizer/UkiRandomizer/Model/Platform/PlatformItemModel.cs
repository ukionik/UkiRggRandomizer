using System;

namespace UkiRandomizer.Model.Platform;

public class PlatformItemModel
{
    public int Id { get; }
    public string ShortName { get; }
    public string FullName { get; }
    public Uri ImageUrl { get; }

    public PlatformItemModel(Entity.Platform platform, Uri resourceUrl)
    {
        Id = platform.Id;
        ShortName = platform.ShortName;
        FullName = platform.FullName;
        var fileName = $"{ShortName.Replace(" ", "").ToLower()}.png";
        ImageUrl = new Uri(resourceUrl, $"images/consoles/{fileName}");
    }
}