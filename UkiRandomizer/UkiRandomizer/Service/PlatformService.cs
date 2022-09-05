using System.Collections.Generic;
using System.Linq;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Platform;
using UkiRandomizer.Repository;

namespace UkiRandomizer.Service;

[Service]
public class PlatformService : IPlatformService
{
    private readonly IGlobalRepository _globalRepository;
    private readonly IPlatformRepository _platformRepository;

    public PlatformService(IPlatformRepository platformRepository
        , IGlobalRepository globalRepository)
    {
        _platformRepository = platformRepository;
        _globalRepository = globalRepository;
    }

    public List<PlatformItemModel> FindPlatforms()
    {
        return _platformRepository.Data
            .Select(x => new PlatformItemModel(x, _globalRepository.HostUrl))
            .ToList();
    }
}