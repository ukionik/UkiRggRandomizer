using UkiRandomizer.Core;
using UkiRandomizer.Core.Repository;
using UkiRandomizer.Model.Entity;
using UkiRandomizer.Service;

namespace UkiRandomizer.Repository;

[Repository]
public class ProfileRepository : CrudCollectionRepository<int, Profile>
    , IProfileRepository
{
    private static readonly string DefaultProfileName = "Default";

    public ProfileRepository(IDbService dbService)
        : base(dbService)
    {
    }

    public void CreateDefaultIfNotExists()
    {
        DbService.ExecuteQuery(db =>
        {
            var profileCollection = db.GetCollection<Profile>();
            var profile = profileCollection.FindOne(x => x.Name == DefaultProfileName);

            if (profile != null)
                return;
            
            
            profile = new Profile
            {
                Name = DefaultProfileName
            };
            profileCollection.Insert(profile);
        });
    }
}