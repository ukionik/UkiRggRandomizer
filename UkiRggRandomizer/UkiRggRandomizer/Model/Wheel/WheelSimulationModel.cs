using System.Collections.Generic;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelSimulationModel
{
    public WheelSimulationModel(string songPath, string fanfarePath, List<WheelItemSchedule> schedule, int realDuration)
    {
        SongPath = songPath;
        FanfarePath = fanfarePath;
        Schedule = schedule;
        RealDuration = realDuration;
    }

    public string SongPath { get; }
    public string FanfarePath { get; }
    public List<WheelItemSchedule> Schedule { get; }
    public int RealDuration { get; }
}