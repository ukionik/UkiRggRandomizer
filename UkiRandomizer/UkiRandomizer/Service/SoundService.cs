using System;
using System.IO;
using NAudio.Wave;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Wheel;
using UkiRandomizer.Repositories;

namespace UkiRandomizer.Service;

[Service]
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