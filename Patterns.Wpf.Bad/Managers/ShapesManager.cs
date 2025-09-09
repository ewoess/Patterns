using Patterns.Wpf.Bad.Models;
using Patterns.Wpf.Bad.ViewModels.Shapes;
using Rectangle = Patterns.Wpf.Bad.Models.Rectangle;

namespace Patterns.Wpf.Bad.Managers;

public class ShapesManager
{
    // This is a mock data source, in a real application this would be replaced with a database or an API call
    private List<IShape> _shapes = new List<IShape>();
    
    public void LoadShapes()
    {
        // this is just a mock, but imagine this is where you load all the tables from the database using say entity framework or dapper
        _shapes.AddRange(
        [
            new Rectangle {Id = 1, Length = 15, Width = 15},
            new Rectangle {Id = 2, Length = 30, Width = 30},
            new Rectangle {Id = 3, Length = 50, Width = 50}
        ]);
        _shapes.AddRange(
        [
            new Circle {Id = 1, Radius = 15},
            new Circle {Id = 2, Radius = 30},
            new Circle {Id = 3, Radius = 50}
        ]);
    }

    public List<IShape> GetShapes()
    {
        return _shapes;
    }

    public void CalculateShapeArea(IShapeViewModel shapeViewModel)
    {
        if (shapeViewModel is RectangleViewModel rectangle)
        {
            rectangle.Area = rectangle.Width * rectangle.Height;
        }
        else if (shapeViewModel is CircleViewModel circle)
        {
            circle.Area = Math.PI * Math.Pow(circle.Width / 2, 2);
        }
    }
}