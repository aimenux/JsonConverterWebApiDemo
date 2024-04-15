using Application.Abstractions;

namespace Application.UseCases.Queries;

public sealed class GetShapesQueryHandler : IRequestHandler<GetShapesQuery, GetShapesQueryResponse>
{
    private readonly IShapesRepository _shapesRepository;

    public GetShapesQueryHandler(IShapesRepository shapesRepository)
    {
        _shapesRepository = shapesRepository ?? throw new ArgumentNullException(nameof(shapesRepository));
    }

    public async Task<GetShapesQueryResponse> Handle(GetShapesQuery query, CancellationToken cancellationToken)
    {
        var shapes = await _shapesRepository.GetShapesAsync(cancellationToken);
        return new GetShapesQueryResponse
        {
            Shapes = shapes
        };
    }
}