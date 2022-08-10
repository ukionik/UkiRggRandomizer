namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngineParams
{
    public int DurationSec { get; }
    public int Duration => DurationSec * 1000;
    
    public bool Shuffle { get; }
    public WheelItemDisplayCount WheelItemDisplayCount { get; }

    public WheelEngineParams(int durationSec, bool shuffle = true, WheelItemDisplayCount wheelItemDisplayCount = WheelItemDisplayCount.Five)
    {
        DurationSec = durationSec;
        Shuffle = shuffle;
        WheelItemDisplayCount = wheelItemDisplayCount;
    }
}