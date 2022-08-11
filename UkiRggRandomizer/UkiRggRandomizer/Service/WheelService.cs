using System.Collections.Generic;
using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Service;

public class WheelService : IWheelService
{
    private readonly List<WheelItem> _items = new()
    {
        new WheelItem(1, "Battletoads"),
        new WheelItem(2, "Contra"),
        new WheelItem(3, "Darkwing Duck"),
        new WheelItem(4, "Battletoads & Double Dragon"),
        new WheelItem(5, "Double Dragon II"),
        new WheelItem(6, "Felix The Cat"),
        new WheelItem(7, "Mega Man 2"),
        new WheelItem(8, "DuckTales"),
        new WheelItem(9, "The Legend of Zelda"),
        new WheelItem(10, "The Guardian Legend"),
        new WheelItem(11, "Adventure Island"),
        new WheelItem(12, "Blaster Master"),
        new WheelItem(13, "Castlevania"),
        new WheelItem(14, "Jungle Book"),
        new WheelItem(15, "The Little Mermaid"),
        new WheelItem(16, "Donkey Kong"),
        new WheelItem(17, "Final Fantasy"),
        new WheelItem(18, "Super Mario Bros."),
        new WheelItem(19, "New Ghostbusters II"),
        new WheelItem(20, "Holy Diver"),
        new WheelItem(21, "Lode Runner"),
        new WheelItem(22, "Metroid"),
        new WheelItem(23, "Monster In My Pocket"),
        new WheelItem(24, "Ninja Gaiden"),
        new WheelItem(25, "Power Blade 2"),
        new WheelItem(26, "Tiny Toon Adventures"),
        new WheelItem(27, "Teenage Mutant Ninja Turtles"),
        new WheelItem(28, "Wai Wai World"),
        new WheelItem(29, "Snake Rattle 'n Roll"),
        new WheelItem(30, "Rockin' Kats")
    };

    public List<WheelItemSchedule> GenerateWheelSchedule(WheelEngineParams wheelEngineParams)
    {
        var wheelEngine = new WheelEngine(_items);
        return wheelEngine.GenerateWheelSchedule(wheelEngineParams);
    }

    public List<WheelItem> GetItems()
    {
        return _items;
    }
}