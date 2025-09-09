namespace Patterns.Wpf.Bad.ViewModels.Shapes;

public interface IShapeViewModel
{
    double Area { get; }
    string Action => "CalculateArea";
}