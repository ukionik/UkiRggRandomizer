using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Model.Sound;
using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Controller;

public class PlayerResource : IResource
{
    [ResourceMethod(RequestMethod.PUT, "play")]
    public void Play(PlaySoundRequest request)
    {
        var mp3Player = new Mp3Player();
        mp3Player.Play(request.SoundPath);
    }
}