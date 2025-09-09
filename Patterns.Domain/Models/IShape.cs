namespace Patterns.Domain.Models;

public interface IShape
{
    public int Id { get; set; }
    public string? Name { get; }

    public double CalculateArea();
}