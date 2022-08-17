using System;

namespace UkiRggRandomizer.Service;

public interface IMp3Player : IDisposable
{
    void Play(string fileName);
    void Stop();
}