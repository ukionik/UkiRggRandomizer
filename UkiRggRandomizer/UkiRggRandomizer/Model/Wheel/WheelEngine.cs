using System;
using System.Collections.Generic;
using UkiRggRandomizer.Core;

namespace UkiRggRandomizer.Model.Wheel;

public class WheelEngine
{
    private readonly int _interval = 8;
    private readonly double _speed = 0.1;
    private double _distance;
    private bool _halfTime;
    private bool _tenTime;

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

        _distance = 0;
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
            CalculateDistance(time, parameters.Duration);
            var position = (int) Math.Round(_distance, MidpointRounding.AwayFromZero) % WheelItems.Count;

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

    private void CalculateDistance(int time, int duration)
    {
        const double halfPi = Math.PI / 2;
        var k = Math.Pow(1 - time / (double) duration, 4);

        var currentSpeed = _speed * k;
        var distance = currentSpeed * _interval;

        if (currentSpeed < _speed / 2 && !_halfTime)
        {
            Console.WriteLine(time);
            _halfTime = true;
        }
        
        if (currentSpeed < _speed / 10 && !_tenTime)
        {
            Console.WriteLine(time);
            _tenTime = true;
        }

        _distance += distance;
        //Console.WriteLine($"Time: {time} Speed: {currentSpeed} Distance: {_distance}");
    }
}