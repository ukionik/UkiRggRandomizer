using System;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelRollSong
{
    public WheelRollSong(TimeSpan totalTime, string fullPath)
    {
        TotalTime = totalTime;
        FullPath = fullPath;
    }

    public TimeSpan TotalTime { get; }
    public string FullPath { get; }
}