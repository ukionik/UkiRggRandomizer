using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Service;

public interface ISoundService
{
    WheelRollSong RandomSong();
    WheelRollSong RandomFanfare();
}