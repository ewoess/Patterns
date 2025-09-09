using Patterns.DataAccess.Models;

namespace Patterns.DataAccess.Mock;

public class RectangleRepository : IRepository<RectangleEntity>
{
    private readonly List<RectangleEntity?> _data =
    [
        new RectangleEntity {Id = 1, Length = 15, Width = 15},
        new RectangleEntity {Id = 2, Length = 30, Width = 30},
        new RectangleEntity {Id = 3, Length = 50, Width = 50}
    ];

    public RectangleEntity? GetById(int id) => _data.FirstOrDefault(c => c != null && c.Id == id);

    public List<RectangleEntity?> GetAll() => _data;

    public void Insert(RectangleEntity? item)
    {
        if (item == null)
        {
            return;
        }

        item.Id = _data.Max(c => c?.Id ?? 0) + 1;
        _data.Add(item);
    }

    public void Update(RectangleEntity item)
    {
        int index = _data.FindIndex(c => c != null && c.Id == item.Id);
        if (index >= 0)
        {
            _data[index] = item;
        }
    }

    public void Delete(RectangleEntity item)
    {
        _data.RemoveAll(c => c != null && c.Id == item.Id);
    }
}