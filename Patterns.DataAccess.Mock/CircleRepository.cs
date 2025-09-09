using Patterns.DataAccess.Models;

namespace Patterns.DataAccess.Mock;

public class CircleRepository : IRepository<CircleEntity>
{
    private readonly List<CircleEntity?> _data =
    [
        new CircleEntity {Id = 1, Radius = 15},
        new CircleEntity {Id = 2, Radius = 30},
        new CircleEntity {Id = 3, Radius = 50}
    ];

    public CircleEntity? GetById(int id) => _data.FirstOrDefault(c => c != null && c.Id == id);

    public List<CircleEntity?> GetAll() => _data;

    public void Insert(CircleEntity? item)
    {
        if (item == null)
        {
            return;
        }

        item.Id = _data.Max(c => c?.Id ?? 0) + 1;
        _data.Add(item);
    }

    public void Update(CircleEntity item)
    {
        int index = _data.FindIndex(c => c != null && c.Id == item.Id);
        if (index >= 0)
        {
            _data[index] = item;
        }
    }

    public void Delete(CircleEntity item)
    {
        _data.RemoveAll(c => c != null && c.Id == item.Id);
    }
}