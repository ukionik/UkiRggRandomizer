using System;

namespace UkiRandomizer.Repository;

public interface IGlobalRepository
{
    Uri HostUrl { get; }
    string AppPath { get; set; }
    string ResourcePath { get; }
    string SoundPath { get; }
    string DbPath { get; }
}