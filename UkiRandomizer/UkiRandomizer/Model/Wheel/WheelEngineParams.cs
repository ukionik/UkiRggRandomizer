namespace UkiRandomizer.Model.Wheel;

public class WheelEngineParams
{
    public int DurationMillis { get; }
    public bool Shuffle { get; }
    public WheelItemDisplayCount WheelItemDisplayCount { get; }

    public WheelEngineParams(int durationMillis, bool shuffle = true, WheelItemDisplayCount wheelItemDisplayCount = WheelItemDisplayCount.Five)
    {
        DurationMillis = durationMillis;
        Shuffle = shuffle;
        WheelItemDisplayCount = wheelItemDisplayCount;
    }
}