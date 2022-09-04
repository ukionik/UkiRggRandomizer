using System.Collections.Generic;
using UkiRandomizer.Model.Platform;

namespace UkiRandomizer.Service;

public interface IPlatformService
{
    List<PlatformItemModel> FindPlatforms();
}