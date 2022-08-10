namespace UkiRggRandomizer.Model.Wheel;

public class WheelItemSchedule
{
    public WheelItemTimeRange Range { get; }
    public WheelItem Item { get; }

    public WheelItemSchedule(WheelItemTimeRange range, WheelItem item)
    {
        Range = range;
        Item = item;
    }

    public override string ToString()
    {
        return $"[{Range.Min}-{Range.Max}] {Item.Name}";
    }
}