using UkiRandomizer.Model.Wheel;

namespace UkiRandomizer.Service;

public interface IWheelService
{
    WheelSimulationModel SimulateWheel();
}