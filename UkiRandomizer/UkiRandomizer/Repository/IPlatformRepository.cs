using System;
using UkiRandomizer.Core.Repository;
using UkiRandomizer.Model.Entity;

namespace UkiRandomizer.Repository;

public interface IPlatformRepository : ICollectionRepositoryAsync<int, Platform>
{
}