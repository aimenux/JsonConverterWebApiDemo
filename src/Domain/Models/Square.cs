namespace Domain.Models;

public sealed class Square : IShape
{
    public Guid Id => Guid.NewGuid();
    public string Type => nameof(ShapeType.Square);
    public int Side { get; init; }
}