namespace Domain.Models;

public sealed class Circle : IShape
{
    public Guid Id => Guid.NewGuid();
    public string Type => nameof(ShapeType.Circle);
    public int Radius { get; init; }
}