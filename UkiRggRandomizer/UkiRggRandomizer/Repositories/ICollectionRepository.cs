using System.Collections.Generic;
using System.Threading.Tasks;

namespace UkiRggRandomizer.Repositories;

public interface ICollectionRepository<T>
{
    List<T> Data { get; }
    Task LoadAsync();
}