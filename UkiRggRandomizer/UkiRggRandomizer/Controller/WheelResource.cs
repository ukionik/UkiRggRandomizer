using System.Collections.Generic;
using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Model.Wheel;
using UkiRggRandomizer.Service;

namespace UkiRggRandomizer.Controller;

public class WheelResource : IResource
{
    private readonly IWheelService _wheelService;

    public WheelResource(IWheelService wheelService)
    {
        _wheelService = wheelService;
    }

    [ResourceMethod(RequestMethod.GET, "generate-schedule")]
    public List<WheelItemSchedule> GenerateSchedule()
    {
        return _wheelService.GenerateWheelSchedule();
    }
}