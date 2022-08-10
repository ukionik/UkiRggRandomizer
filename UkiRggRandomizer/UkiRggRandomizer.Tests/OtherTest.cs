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
        Assert.That(value, Is.EqualTo(2));
        value =  (int)Math.Round(0.5, MidpointRounding.AwayFromZero);
        Assert.That(value, Is.EqualTo(1));
        value =  (int)Math.Round(0.49, MidpointRounding.AwayFromZero);
        Assert.That(value, Is.EqualTo(0));
        value =  (int)Math.Round(1.49, MidpointRounding.AwayFromZero);
        Assert.That(value, Is.EqualTo(1));
    }
}