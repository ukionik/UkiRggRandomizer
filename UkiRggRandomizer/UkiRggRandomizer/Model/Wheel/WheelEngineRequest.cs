namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngineRequest
{
    public int DurationSec { get; set; }

    public WheelEngineParams ToWheelEngineParams()
    {
        return new WheelEngineParams(DurationSec);
    }
}