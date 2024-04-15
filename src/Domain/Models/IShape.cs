namespace Domain.Models;

public interface IShape
{
    public Guid Id { get; }
    public string Type { get; }
}