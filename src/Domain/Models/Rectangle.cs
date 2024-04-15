namespace Domain.Models;

public sealed class Rectangle : IShape
{
    public Guid Id => Guid.NewGuid();
    public string Type => "Rectangle";
    public int Length { get; init; }
    public int Width { get; init; }
}