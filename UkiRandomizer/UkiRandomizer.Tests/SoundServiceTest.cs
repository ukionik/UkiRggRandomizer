using UkiRandomizer.Service;
using UkiRandomizer.Tests.Core;

namespace UkiRandomizer.Tests;

public class SoundServiceTest
{
    private SoundService _soundService;

    [SetUp]
    public void SetUp()
    {
        _soundService = new SoundService(new GlobalRepositoryTest());
    }

    [Test]
    public void RandomSongTest()
    {
        var randomSong = _soundService.RandomSong();
        Console.WriteLine(randomSong);
    }
}