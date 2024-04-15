namespace Api.Presentation.V1.GetShapes;

public sealed class GetShapesProfile : Profile
{
    public GetShapesProfile()
    {
        CreateMap<IShape, IShapeDto>()
            .Include<Circle, CircleDto>()
            .Include<Square, SquareDto>()
            .Include<Rectangle, RectangleDto>();
        CreateMap<Circle, CircleDto>();
        CreateMap<Square, SquareDto>();
        CreateMap<Rectangle, RectangleDto>();
        CreateMap<GetShapesRequest, GetShapesQuery>();
        CreateMap<GetShapesQueryResponse, GetShapesResponse>();
    }
}