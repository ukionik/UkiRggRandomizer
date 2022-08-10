namespace UkiRggRandomizer.Model.Wheel;

public class WheelItem
{
    public string Name { get; }

    public WheelItem(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}