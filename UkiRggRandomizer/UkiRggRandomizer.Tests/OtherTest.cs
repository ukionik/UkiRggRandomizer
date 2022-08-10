using UkiRggRandomizer.Core;
using static NUnit.Framework.Assert;

namespace UkiRggRandomizer.Tests;

public class OtherTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void RoundTest()
    {
        var value =  (int)Math.Round(1.5, MidpointRounding.AwayFromZero);
        That(value, Is.EqualTo(2));
        value =  (int)Math.Round(0.5, MidpointRounding.AwayFromZero);
        That(value, Is.EqualTo(1));
        value =  (int)Math.Round(0.49, MidpointRounding.AwayFromZero);
        That(value, Is.EqualTo(0));
        value =  (int)Math.Round(1.49, MidpointRounding.AwayFromZero);
        That(value, Is.EqualTo(1));
    }

    [Test]
    public void PreviousItemsTest()
    {
        var items = new List<int>
        {
            1,2,3,4,5,6,7,8,9,10
        };

        var item = items[4];

        That(item, Is.EqualTo(5));
        var previousItems = items.GetPreviousItems(item, 7);
        That(previousItems, Has.Count.EqualTo(7) );
        That(previousItems[0], Is.EqualTo(8));
        That(previousItems[1], Is.EqualTo(9));
        That(previousItems[2], Is.EqualTo(10));
        That(previousItems[3], Is.EqualTo(1));
        That(previousItems[4], Is.EqualTo(2));
        That(previousItems[5], Is.EqualTo(3));
        That(previousItems[6], Is.EqualTo(4));
    }
    
    [Test]
    public void NextItemsTest()
    {
        var items = new List<int>
        {
            1,2,3,4,5,6,7,8,9,10
        };

        var item = items[6];

        That(item, Is.EqualTo(7));
        var nextItems = items.GetNextItems(item, 7);
        That(nextItems, Has.Count.EqualTo(7) );
        That(nextItems[0], Is.EqualTo(8));
        That(nextItems[1], Is.EqualTo(9));
        That(nextItems[2], Is.EqualTo(10));
        That(nextItems[3], Is.EqualTo(1));
        That(nextItems[4], Is.EqualTo(2));
        That(nextItems[5], Is.EqualTo(3));
        That(nextItems[6], Is.EqualTo(4));
    }
}