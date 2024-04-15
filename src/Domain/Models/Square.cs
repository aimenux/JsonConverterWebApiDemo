namespace Domain.Models;

public sealed class Square : IShape
{
    public Guid Id => Guid.NewGuid();
    public string Type => "Square";
    public int Side { get; init; }
}