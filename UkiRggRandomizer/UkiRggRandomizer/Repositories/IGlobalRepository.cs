﻿namespace UkiRggRandomizer.Repositories;

public interface IGlobalRepository
{
    string AppPath { get; set; }
    string ResourcePath { get; }
    string SoundPath { get; }
}