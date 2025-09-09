using Patterns.Domain.Models;

namespace Patterns.Domain.Services;

public interface IShapeService
{
    IReadOnlyList<IShape> GetAllShapes();
}