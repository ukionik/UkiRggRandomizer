using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Wheel;
using UkiRandomizer.Service;

namespace UkiRandomizer.Controller;

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