using System.Collections.Generic;
using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Platform;
using UkiRandomizer.Service;

namespace UkiRandomizer.Controller;

[Resource]
public class PlatformResource
{
    private readonly IPlatformService _platformService;

    public PlatformResource(IPlatformService platformService)
    {
        _platformService = platformService;
    }

    [ResourceMethod(RequestMethod.GET, "list")]
    public List<PlatformItemModel> List()
    {
        return _platformService.FindPlatforms();
    }
}