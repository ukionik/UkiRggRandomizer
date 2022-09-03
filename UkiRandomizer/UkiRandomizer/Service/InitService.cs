using UkiRandomizer.Core;
using UkiRandomizer.Repository;

namespace UkiRandomizer.Service;

[Service]
public class InitService : IInitService
{
    private readonly IProfileRepository _profileRepository;

    public InitService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public void Init()
    {
        _profileRepository.CreateDefaultIfNotExists();
    }
}