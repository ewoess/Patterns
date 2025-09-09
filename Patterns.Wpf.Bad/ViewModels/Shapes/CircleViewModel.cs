using Patterns.Wpf.Bad.Models;
using Prism.Mvvm;

namespace Patterns.Wpf.Bad.ViewModels.Shapes;

public class CircleViewModel : BindableBase, IShapeViewModel
{
    private Circle _circle;

    public CircleViewModel(Circle circle)
    {
        _circle = circle;
        Width = circle.Radius * 2;
        Height = circle.Radius * 2;
    }
    
    private double _width;
    public double Width
    {
        get => _width;
        set
        {
            SetProperty(ref _width, value);
            _circle.Radius = value / 2;
        }
    }

    private double _height;
    public double Height
    {
        get => _height;
        set
        {
            SetProperty(ref _height, value);
            _circle.Radius = value / 2;
        }
    }

    private double _area;
    public double Area 
    { 
        get => _area;
        set => SetProperty(ref _area, value);
    }
}