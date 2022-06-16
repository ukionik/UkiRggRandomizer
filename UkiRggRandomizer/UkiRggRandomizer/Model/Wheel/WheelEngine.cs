using System.Collections.Generic;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngine
{
    private readonly List<WheelItem> _wheelItems;

    public WheelEngine(List<WheelItem> wheelItems)
    {
        _wheelItems = wheelItems;
    }

    public void Roll(WheelEngineParams parameters)
    {
        
    }
}