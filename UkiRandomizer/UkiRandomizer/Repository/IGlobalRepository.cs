namespace UkiRandomizer.Repository;

public interface IGlobalRepository
{
    string AppPath { get; set; }
    string ResourcePath { get; }
    string SoundPath { get; }
    string DbPath { get; }
}