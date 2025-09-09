namespace Patterns.DataAccess.Models;

public class RectangleEntity : IEntity
{
    public int Id { get; set; }

    public double Width { get; set; }
    public double Length { get; set; }
}