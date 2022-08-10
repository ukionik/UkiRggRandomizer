using System;
using System.Collections.Generic;
using UkiRggRandomizer.Core;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngine
{
    private readonly int _interval = 10;
    private readonly double _speed = 0.05;
    private double _currentDistance;

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

        _currentDistance = 0;
        var scheduleList = new List<WheelItemSchedule>();
        var range = new WheelItemTimeRange
        {
            Min = 0
        };
        var prevPosition = 0;

        var dict = new Dictionary<int, dynamic>();

        var prevOrNextCount = parameters.WheelItemDisplayCount.GetPrevOrNextLength();
        WheelItems.ForEach(item =>
        {
            var prevItems = WheelItems.GetPreviousItems(item, prevOrNextCount);
            var nextItems = WheelItems.GetNextItems(item, prevOrNextCount);
            dict[WheelItems.IndexOf(item)] = new
            {
                PrevItems = prevItems,
                CurrentItem = item,
                NextItems = nextItems
            };
        });

        for (var time = _interval; time < parameters.Duration; time += _interval)
        {
            _currentDistance = CalculateDistance(time, parameters.Duration);
            var position = (int) Math.Round(_currentDistance, MidpointRounding.AwayFromZero) % WheelItems.Count;

            //Если цикл не последний
            if (time + _interval < parameters.Duration)
            {
                if (prevPosition == position)
                    continue;

                var content = dict[prevPosition];

                range.Max = time;
                scheduleList.Add(
                    new WheelItemSchedule(range, content.PrevItems, content.CurrentItem, content.NextItems));
                range = new WheelItemTimeRange
                {
                    Min = time
                };
                prevPosition = position;
            }
            //Если последний цикл
            else
            {
                var content = dict[prevPosition];
                range.Max = time + _interval;
                scheduleList.Add(
                    new WheelItemSchedule(range, content.PrevItems, content.CurrentItem, content.NextItems));
            }
        }

        return scheduleList;
    }

    private double CalculateDistance(int time, int duration)
    {
        double speed;
        //Если время меньше половины, начинаем ускорять колесо
        if (time <= duration / 2)
        {
            /*var acceleration = Math.Pow(1 - (time - duration / 2.0) / duration, Math.E);*/
            var acceleration = Math.Pow(time * 2 / (double)duration, 1/Math.E);
            Console.WriteLine(acceleration);
            speed = _speed * acceleration;
        }
        //Если время больше половины, то начинаем замедлять колесо
        else
        {
            var slowdown = Math.Pow(1.5 - time / (double)duration, Math.E);
            speed = _speed * slowdown;
        }


        if (speed < _speed / 2)
        {
            //Console.WriteLine(time);
        }

        //Console.WriteLine($"Time: {time}, Speed: {speed}");
        return _currentDistance + speed * _interval;
    }
}