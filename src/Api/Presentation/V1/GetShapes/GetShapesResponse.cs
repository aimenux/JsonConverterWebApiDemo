namespace Api.Presentation.V1.GetShapes;

public sealed class GetShapesResponse
{
    public ICollection<IShapeDto> Shapes { get; init; } = [];
}

public interface IShapeDto
{
    public Guid Id { get; }
    public string Type { get; }
}

public sealed class CircleDto : IShapeDto
{
    public required Guid Id { get; init; }
    public required string Type { get; init; }
    public required int Radius { get; init; }
}

public sealed class SquareDto : IShapeDto
{
    public required Guid Id { get; init; }
    public required string Type { get; init; }
    public required int Side { get; init; }
}

public sealed class RectangleDto : IShapeDto
{
    public required Guid Id { get; init; }
    public required string Type { get; init; }
    public required int Length { get; init; }
    public required int Width { get; init; }
}