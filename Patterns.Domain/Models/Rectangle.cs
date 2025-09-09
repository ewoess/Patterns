namespace Patterns.Domain.Models;

public class Rectangle : IShape
{
    public int Id { get; set; }
    public string? Name => "Rectangle";

    public double Width { get; set; }
    public double Length { get; set; }
    
    public double CalculateArea()
    {
        return Length * Width;
    }
}