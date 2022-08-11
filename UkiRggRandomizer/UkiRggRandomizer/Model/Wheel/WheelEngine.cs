using System;
using System.Collections.Generic;
using UkiRggRandomizer.Core;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngine
{
    private readonly int _interval = 8;
    private readonly Random _random;
    private readonly double _baseSpeed = 0.1;
    private double _speed;
    private double _distance;

    public List<WheelItem> WheelItems { get; }

    public WheelEngine(List<WheelItem> wheelItems)
    {
        WheelItems = wheelItems;
        _random = new Random(DateTime.Now.Millisecond);
    }

    public void Shuffle()
    {
        WheelItems.Shuffle(_random);
    }

    public List<WheelItemSchedule> GenerateWheelSchedule(WheelEngineParams parameters)
    {
        if (parameters.Shuffle)
        {
            Shuffle();
        }

        _speed = _baseSpeed + _baseSpeed * (_random.Next(0, 11) / 100.0);

        _distance = 0;
        var duration = (int)(parameters.Duration + parameters.Duration * (_random.Next(0, 6) / 100.0));
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

        for (var time = _interval; time < duration; time += _interval)
        {
            CalculateDistance(time, duration);
            var position = (int) Math.Round(_distance, MidpointRounding.AwayFromZero) % WheelItems.Count;

            //Если цикл не последний
            if (time + _interval < duration)
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

    private void CalculateDistance(int time, int duration)
    {
        var minSpeed = _speed / 100;

        double currentSpeed;
        double k;
        if (time <= duration / 2)
        {
            k = Math.Pow(2 * time / (double) duration, 2);
            currentSpeed = minSpeed + (_speed - minSpeed) * k;
        }
        else
        {
            k = Math.Pow(2 - 2 * time / (double) duration, 8);
            currentSpeed = minSpeed + (_speed - minSpeed) * k;
        }

        var distance = currentSpeed * _interval;

        _distance += distance;
        //Console.WriteLine($"Time: {time} Speed: {currentSpeed} Distance: {_distance}");
    }
}