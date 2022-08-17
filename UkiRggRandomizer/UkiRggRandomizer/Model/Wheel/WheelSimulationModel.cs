using System.Collections.Generic;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelSimulationModel
{
    public WheelSimulationModel(string songPath, List<WheelItemSchedule> schedule, int realDuration)
    {
        SongPath = songPath;
        Schedule = schedule;
        RealDuration = realDuration;
    }

    public string SongPath { get; }
    public List<WheelItemSchedule> Schedule { get; }
    public int RealDuration { get; }
}