using Patterns.Domain.Models;

namespace Patterns.Wpf.ViewModels;

public class RectangleViewModel : ShapeViewModel
{
    private double _width;

    public double Width
    {
        get => _width;
        set => SetProperty(ref _width, value);
    }

    private double _height;

    public double Height
    {
        get => _height;
        set => SetProperty(ref _height, value);
    }

    public RectangleViewModel(Rectangle shape) : base(shape)
    {
        Width = shape.Width;
        Height = shape.Length;
    }
}