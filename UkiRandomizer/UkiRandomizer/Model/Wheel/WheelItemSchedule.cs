using System.Collections.Generic;

namespace UkiRandomizer.Model.Wheel;

public class WheelItemSchedule
{
    public WheelItemTimeRange Range { get; }
    public List<WheelItem> PreviousItems { get; }
    public WheelItem CurrentItem { get; }
    public List<WheelItem> NextItems { get; }

    public WheelItemSchedule(WheelItemTimeRange range
        , List<WheelItem> previousItems
        , WheelItem currentItem
        , List<WheelItem> nextItems)
    {
        Range = range;
        PreviousItems = previousItems;
        CurrentItem = currentItem;
        NextItems = nextItems;
    }

    public override string ToString()
    {
        return $"[{Range.Min}-{Range.Max}] ({string.Join(", ", PreviousItems)}) {CurrentItem} ({string.Join(", ", NextItems)})";
    }
}