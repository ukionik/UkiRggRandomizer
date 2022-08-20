using System.Collections.Generic;
using System.Threading.Tasks;
using UkiRandomizer.Model.Entity;

namespace UkiRandomizer.Service;

public interface ISheetService
{
    Task<List<Platform>> LoadPlatformsAsync();
}