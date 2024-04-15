using Domain.Models;

namespace Application.Abstractions;

public interface IShapesRepository
{
    Task<ICollection<IShape>> GetShapesAsync(CancellationToken cancellationToken);
}