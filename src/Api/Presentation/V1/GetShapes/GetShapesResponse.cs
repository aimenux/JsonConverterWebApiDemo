namespace Api.Presentation.V1.GetShapes;

public sealed class GetShapesResponse
{
    public ICollection<IShapeDto> Shapes { get; init; } = [];
}

public interface IShapeDto
{
    public Guid Id { get; }
    public string? Type { get; }
}

public sealed class CircleDto : IShapeDto
{
    public Guid Id { get; init; }
    public string? Type { get; init; }
    
    public int Radius { get; init; }
}

public sealed class SquareDto : IShapeDto
{
    public Guid Id { get; init; }
    public string? Type { get; init; }
    public int Side { get; init; }
}

public sealed class RectangleDto : IShapeDto
{
    public Guid Id { get; init; }
    public string? Type { get; init; }
    public int Length { get; init; }
    public int Width { get; init; }
}