using Patterns.Domain.Models;

namespace Patterns.Wpf.ViewModels;

public static class ShapeViewModelFactory
{
    public static ShapeViewModel Create(IShape shape)
    {
        return shape switch
        {
            Rectangle r => new RectangleViewModel(r),
            Circle c => new CircleViewModel(c), 
            _ => throw new ArgumentOutOfRangeException(nameof(shape))
        };
    }
}