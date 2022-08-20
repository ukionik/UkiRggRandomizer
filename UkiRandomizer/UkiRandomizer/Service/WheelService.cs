using System;
using System.Collections.Generic;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Wheel;

namespace UkiRandomizer.Service;

[Service]
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

    private readonly ISoundService _soundService;

    public WheelService(ISoundService soundService)
    {
        _soundService = soundService;
    }

    public WheelSimulationModel SimulateWheel()
    {
        var wheelRollSong = _soundService.RandomSong();
        var fanfare = _soundService.RandomFanfare();
        var wheelEngine = new WheelEngine(_items);
        var duration = RandomDuration((int)wheelRollSong.TotalTime.TotalMilliseconds);
        var parameters = new WheelEngineParams(duration);
        var wheelEngineParams = new WheelEngineParams((int)wheelRollSong.TotalTime.TotalMilliseconds);
        var schedule = wheelEngine.GenerateWheelSchedule(wheelEngineParams);
        return new WheelSimulationModel(wheelRollSong.FullPath, fanfare.FullPath, schedule, parameters.DurationMillis);
    }
    
    public List<WheelItem> GetItems()
    {
        return _items;
    }
    
    private int RandomDuration(int durationMillis)
    {
        var random = new Random(DateTime.Now.Millisecond);
        var duration = (int)(durationMillis + durationMillis * (random.Next(0, 6) / 100.0));
        return duration;
    }
}