namespace Patterns.Domain.Models;

public class Circle : IShape
{
    public int Id { get; set; }
    
    public string Name => "Circle";

    public double Radius { get; set; }
    
    public double CalculateArea()
    {
        return 2 * Math.PI * Radius * Radius;
    }
}