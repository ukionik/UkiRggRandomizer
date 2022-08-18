using System.Collections.Generic;
using System.Threading.Tasks;
using UkiRggRandomizer.Model.Entity;

namespace UkiRggRandomizer.Service;

public interface ISheetService
{
    Task<List<Platform>> LoadPlatformsAsync();
}