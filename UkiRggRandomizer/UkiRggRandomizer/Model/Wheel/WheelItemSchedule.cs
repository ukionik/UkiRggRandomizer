using System.Collections.Generic;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelItemSchedule
{
    public WheelItemTimeRange Range { get; }
    public int ItemIndex { get; }

    public WheelItemSchedule(WheelItemTimeRange range, int itemIndex)
    {
        Range = range;
        ItemIndex = itemIndex;
    }

    public override string ToString()
    {
        return $"[{Range.Min}-{Range.Max}] {ItemIndex}";
    }
}