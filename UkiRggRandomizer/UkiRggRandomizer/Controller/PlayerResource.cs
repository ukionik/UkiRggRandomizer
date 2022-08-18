using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRggRandomizer.Core;
using UkiRggRandomizer.Model.Sound;
using UkiRggRandomizer.Model.Wheel;

namespace UkiRggRandomizer.Controller;

[Resource]
public class PlayerResource
{
    [ResourceMethod(RequestMethod.PUT, "play")]
    public void Play(PlaySoundRequest request)
    {
        var mp3Player = new Mp3Player();
        mp3Player.Play(request.SoundPath);
    }
}