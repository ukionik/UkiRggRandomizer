namespace UkiRggRandomizer.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }

    [Test]
    public void Kekw()
    {
        var attempts = 10000;
        var stat = new List<long>();
        var random = new Random(DateTime.Now.Millisecond);
        for (var i = 0; i < attempts; i++) stat.Add(Random(random));

        var avg = stat.Average();
    }

    private long Random(Random random)
    {
        var fail = true;
        var counter = 0L;

        while (fail)
        {
            var val1 = random.Next(100);
            var val2 = random.Next(100);
            var val3 = random.Next(100);


            if (
                (val1 == 50 && val2 == 50)
                || (val1 == 50 && val3 == 50)
                || (val2 == 50 && val3 == 50)
                || (val1 == 50 && val2 == 50 && val3 == 50)
            )
            {
                fail = false;
                var platform1 = random.Next(10);
                var platform2 = random.Next(9);

                if (platform1 == 5 && platform2 == 5)
                {
                    fail = false;
                }
            }

            counter++;
        }

        return counter;
    }
}