using Patterns.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace Patterns.Wpf.ViewModels;

public class ShapeViewModel : BindableBase
{
    public IShape Shape { get; }
    public DelegateCommand CalculateAreaCommand { get; }
    
    private double _area;
    public double Area 
    { 
        get => _area;
        set => SetProperty(ref _area, value);
    }
    
    protected ShapeViewModel (IShape shape)
    {
        Shape = shape;
        CalculateAreaCommand = new DelegateCommand(CalculateArea);
    }

    public void CalculateArea()
    {
        Area = Shape.CalculateArea();
    }
}