namespace Infrastructure.Repositories;

public class ShapesRepository : IShapesRepository
{
    private static readonly ConcurrentDictionary<Guid, IShape> Shapes = new();

    public ShapesRepository()
    {
        var circle = new Circle { Radius = 2 };
        var square = new Square { Side = 3 };
        var rectangle = new Rectangle { Length = 2, Width = 3 };
        Shapes.TryAdd(circle.Id, circle);
        Shapes.TryAdd(square.Id, square);
        Shapes.TryAdd(rectangle.Id, rectangle);
    }
    
    public async Task<ICollection<IShape>> GetShapesAsync(CancellationToken cancellationToken)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        return Shapes.Values;
    }
}