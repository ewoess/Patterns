using Patterns.DataAccess.Models;

namespace Patterns.DataAccess;

public interface ICachingRepository<T> where T : IEntity
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Insert(T item);
    void Update(T item);
    void Delete(T item);

    // Caching methods
    // void ClearCache();
    // bool IsCached(int id);
    // T? GetFromCache(int id);
}