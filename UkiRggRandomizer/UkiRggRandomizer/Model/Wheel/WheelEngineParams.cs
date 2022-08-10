namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngineParams
{
    public int DurationSec { get; }
    public int Duration => DurationSec * 1000;
    
    public bool Shuffle { get; }

    public WheelEngineParams(int durationSec, bool shuffle = true)
    {
        DurationSec = durationSec;
        Shuffle = shuffle;
    }
}