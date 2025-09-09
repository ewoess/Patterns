using Patterns.Domain.Models;

namespace Patterns.Wpf.ViewModels;

public class CircleViewModel : ShapeViewModel
{
    private double _radius;
    public double Radius
    {
        get => _radius;
        set
        {
            SetProperty(ref _radius, value);
            ((Circle)Shape).Radius = value;
            Width = value * 2;
            Height = value * 2;
        }
    }
    
    private double _width;
    public double Width 
    { 
        get => _width;
        private set => SetProperty(ref _width, value);
    }
    
    private double _height;
    public double Height 
    { 
        get => _height;
        private set => SetProperty(ref _height, value);
    }

    public CircleViewModel(Circle shape) : base(shape)
    {
        Radius = shape.Radius;
    }
    
    
}