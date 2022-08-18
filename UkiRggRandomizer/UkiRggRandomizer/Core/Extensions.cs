using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GenHTTP.Modules.Layouting.Provider;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Controller;
using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Core;

public static class Extensions
{
    public static string ToKebabCase(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return Regex.Replace(
                value,
                "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])",
                "-$1",
                RegexOptions.Compiled)
            .Trim()
            .ToLower();
    }

    public static void Shuffle<T>(this IList<T> list, Random r)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = r.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }

    public static int GetPrevOrNextLength(this WheelItemDisplayCount value)
    {
        return value switch
        {
            WheelItemDisplayCount.Three => 1,
            WheelItemDisplayCount.Five => 2,
            WheelItemDisplayCount.Seven => 3,
            WheelItemDisplayCount.Nine => 4,
            WheelItemDisplayCount.Eleven => 5,
            _ => 1
        };
    }

    public static List<T> GetPreviousItems<T>(this IList<T> list, T item, int prevItemCount)
    {
        if (prevItemCount < 1) return new List<T>();

        var index = list.IndexOf(item);

        var prevList = new List<T>();
        for (var i = prevItemCount; i >= 1; i--)
        {
            var value = index - i;
            var prevItem = value >= 0
                ? list[value]
                : list[^-value];
            prevList.Add(prevItem);
        }

        return prevList;
    }

    public static List<T> GetNextItems<T>(this IList<T> list, T item, int nextItemCount)
    {
        if (nextItemCount < 1) return new List<T>();

        var index = list.IndexOf(item);

        var nextList = new List<T>();
        for (var i = 1; i <= nextItemCount; i++)
        {
            var value = index + i;
            var nextItem = value < list.Count
                ? list[value]
                : list[value - list.Count];
            nextList.Add(nextItem);
        }

        return nextList;
    }

    public static T RandomItem<T>(this IList<T> list, Random random)
    {
        var i = random.Next(list.Count);
        return list[i];
    }
}