using Patterns.Wpf.Bad.Models;
using Prism.Mvvm;

namespace Patterns.Wpf.Bad.ViewModels.Shapes;

public class RectangleViewModel : BindableBase, IShapeViewModel
{
    private Rectangle _rectangle;
    
    private double _width;
    public double Width
    {
        get => _width;
        set
        {
            SetProperty(ref _width, value);
            _rectangle.Width = value;
        }
    }

    private double _height;
    public double Height
    {
        get => _height;
        set
        {
            SetProperty(ref _height, value);
            _rectangle.Length = value;
        }
    }

    private double _area;
    public double Area 
    { 
        get => _area;
        set => SetProperty(ref _area, value);
    }

    public RectangleViewModel(Rectangle rectangle)
    {
        _rectangle = rectangle;
        Width = _rectangle.Width;
        Height = _rectangle.Length;
    }
}