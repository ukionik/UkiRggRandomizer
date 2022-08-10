namespace UkiRggRandomizer.Model.Wheel;

public class WheelItem
{
    public int Index { get; }
    public string Name { get; }

    public WheelItem(int index, string name)
    {
        Index = index;
        Name = name;
    }

    public override string ToString()
    {
        return $"{Index}. {Name}";
    }
}