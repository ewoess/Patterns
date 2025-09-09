using Patterns.DataAccess.Models;
using System.Collections.Concurrent;

namespace Patterns.DataAccess.Mock;

public class CachingRepository<T> : ICachingRepository<T>, ICacheWarmable
    where T : IEntity
{
    private readonly IRepository<T> _innerRepository;
    private readonly ConcurrentDictionary<int, T> _cache = new ConcurrentDictionary<int, T>();

    public CachingRepository(IRepository<T> innerRepository)
    {
        _innerRepository = innerRepository;
    }

    public T GetById(int id)
    {
        if (_cache.TryGetValue(id, out T? cached))
        {
            return cached;
        }

        T? item = _innerRepository.GetById(id);
        if (item != null)
        {
            _cache.TryAdd(item.Id, item);
        }

        return item;
    }

    public IEnumerable<T> GetAll()
    {
        if (_cache.IsEmpty)
        {
            foreach (var item in _innerRepository.GetAll())
            {
                _cache[item.Id] = item;
            }
        }
        return _cache.Values.ToList();
    }

    public void Insert(T item)
    {
        _innerRepository.Insert(item);
        _cache[item.Id] = item;
    }

    public void Update(T item)
    {
        _innerRepository.Update(item);
        _cache[item.Id] = item;
    }

    public void Delete(T item)
    {
        _innerRepository.Delete(item);
        _cache.TryRemove(item.Id, out _);
    }

    public void WarmUp() => GetAll();
}