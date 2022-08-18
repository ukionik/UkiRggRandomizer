using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Core;
using UkiRggRandomizer.Model.Wheel;
using UkiRggRandomizer.Service;

namespace UkiRggRandomizer.Controller;

[Resource]
public class WheelResource
{
    private readonly IWheelService _wheelService;

    public WheelResource(IWheelService wheelService)
    {
        _wheelService = wheelService;
    }

    [ResourceMethod(RequestMethod.PUT, "simulate-wheel")]
    public WheelSimulationModel SimulateWheel(WheelEngineRequest request)
    {
        return _wheelService.SimulateWheel();
    }
}