using Domain.Models;

namespace Application.UseCases.Queries;

public sealed record GetShapesQueryResponse
{
    public ICollection<IShape> Shapes { get; init; } = [];
}