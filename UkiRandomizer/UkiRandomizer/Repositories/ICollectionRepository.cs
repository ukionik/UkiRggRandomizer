using System.Collections.Generic;
using System.Threading.Tasks;

namespace UkiRandomizer.Repositories;

public interface ICollectionRepository<T>
{
    List<T> Data { get; }
    Task LoadAsync();
}