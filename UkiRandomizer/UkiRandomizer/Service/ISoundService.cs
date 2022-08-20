using UkiRandomizer.Model.Wheel;

namespace UkiRandomizer.Service;

public interface ISoundService
{
    WheelRollSong RandomSong();
    WheelRollSong RandomFanfare();
}