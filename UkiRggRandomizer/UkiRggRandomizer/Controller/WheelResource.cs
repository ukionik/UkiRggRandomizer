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

    [ResourceMethod(RequestMethod.PUT, "simulate-wheel")]
    public WheelSimulationModel SimulateWheel(WheelEngineRequest request)
    {
        return _wheelService.SimulateWheel();
    }
    
    [ResourceMethod(RequestMethod.PUT, "roll")]
    public void Roll(WheelRollRequest request)
    {
        _wheelService.Roll(request);
    }
}