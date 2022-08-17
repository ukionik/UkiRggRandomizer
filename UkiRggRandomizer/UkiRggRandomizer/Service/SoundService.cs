using System;
using System.IO;
using NAudio.Wave;
using UkiRggRandomizer.Core;
using UkiRggRandomizer.Model.Wheel;
using UkiRggRandomizer.Repositories;

namespace UkiRggRandomizer.Service;

public class SoundService : ISoundService
{
    private readonly IGlobalRepository _globalRepository;

    public SoundService(IGlobalRepository globalRepository)
    {
        _globalRepository = globalRepository;
    }

    public WheelRollSong RandomSong()
    {
        var random = new Random(DateTime.Now.Millisecond);
        var files = Directory.GetFiles(Path.Combine(_globalRepository.SoundPath, "Retro", "Roll"));
        var randomFilePath = files.RandomItem(random);
        return new WheelRollSong(TotalTime(randomFilePath), randomFilePath);
    }

    public WheelRollSong RandomFanfare()
    {
        var random = new Random(DateTime.Now.Millisecond);
        var files = Directory.GetFiles(Path.Combine(_globalRepository.SoundPath, "Retro", "Fanfare"));
        var randomFilePath = files.RandomItem(random);
        return new WheelRollSong(TotalTime(randomFilePath), randomFilePath);
    }

    private TimeSpan TotalTime(string filePath)
    {
        using var fileReader = new Mp3FileReader(filePath);
        return fileReader.TotalTime;
    }
}