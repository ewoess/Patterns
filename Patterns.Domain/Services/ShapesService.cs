using Patterns.DataAccess;
using Patterns.DataAccess.Models;
using Patterns.Domain.Models;

namespace Patterns.Domain.Services;

public class ShapesService : IShapeService
{
    private readonly ICachingRepository<RectangleEntity> _rectangleRepository;
    private readonly ICachingRepository<CircleEntity> _circleRepository;

    public ShapesService(ICachingRepository<RectangleEntity> rectangleRepository, ICachingRepository<CircleEntity> circleRepository)
    {
        _rectangleRepository = rectangleRepository;
        _circleRepository = circleRepository;
    }
    
    public IReadOnlyList<IShape> GetAllShapes()
    {
        List<IShape> shapes = new List<IShape>();
        shapes.AddRange(_rectangleRepository.GetAll().Select(x => new Rectangle
        {
            Id = x.Id,
            Length = x.Length,
            Width = x.Width
        }));
        shapes.AddRange(_circleRepository.GetAll().Select(x => new Circle
        {
            Id = x.Id,
            Radius = x.Radius
        }));
        
        return shapes;
    }
}