using System;
using System.Collections.Generic;
using UkiRggRandomizer.Core;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngine
{
    private readonly int _interval = 10;
    private double _speed = 0.001;

    public List<WheelItem> WheelItems { get; }

    public WheelEngine(List<WheelItem> wheelItems)
    {
        WheelItems = wheelItems;
    }

    public void Shuffle()
    {
        var r = new Random(DateTime.Now.Millisecond);
        WheelItems.Shuffle(r);
    }

    public List<WheelItemSchedule> GenerateWheelSchedule(WheelEngineParams parameters)
    {
        if (parameters.Shuffle)
        {
            Shuffle();            
        }
        
        var scheduleList = new List<WheelItemSchedule>();
        var range = new WheelItemTimeRange
        {
            Min = 0
        };
        var prevPosition = 0;
        for (var time = _interval; time < parameters.Duration; time += _interval)
        {
            var distance = (int)Math.Round(_speed * time, MidpointRounding.AwayFromZero);
            var position = distance % WheelItems.Count;

            //Если цикл не последний
            if (time + _interval < parameters.Duration)
            {
                if (prevPosition == position) 
                    continue;
            
                range.Max = time;
                scheduleList.Add(new WheelItemSchedule(range, WheelItems[prevPosition].Index));
                range = new WheelItemTimeRange
                {
                    Min = time
                };
                prevPosition = position;
            }
            //Если последний цикл
            else
            {
                range.Max = time + _interval;
                scheduleList.Add(new WheelItemSchedule(range, WheelItems[prevPosition].Index));
            }
        }

        return scheduleList;
    }
}