using GenHTTP.Api.Protocol;
using GenHTTP.Modules.Webservices;
using UkiRandomizer.Core;
using UkiRandomizer.Model.Sound;
using UkiRandomizer.Model.Wheel;

namespace UkiRandomizer.Controller;

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