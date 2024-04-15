namespace Tests.UnitTests;

public class GetBooksProfileTests
{
    private static readonly IFixture Fixture = new Fixture();
    
    private static readonly IMapper Mapper = new MapperBuilder()
        .WithProfile<GetShapesProfile>()
        .Build();
    
    [Fact]
    public void Should_Map_GetShapesRequest_To_GetShapesQuery()
    {
        // arrange
        var request = Fixture.Create<GetShapesRequest>();

        // act
        var query = Mapper.Map<GetShapesQuery>(request);

        // assert
        query.Should().NotBeNull();
    }
    
    [Fact]
    public void Should_Map_GetShapesQueryResponse_To_GetShapesResponse()
    {
        // arrange
        var queryResponse = new GetShapesQueryResponse
        {
            Shapes =
            [
                new Circle(),
                new Rectangle(),
                new Square()
            ]
        };

        // act
        var response = Mapper.Map<GetShapesResponse>(queryResponse);

        // assert
        response.Should().NotBeNull();
        response.Shapes.Should().NotBeNullOrEmpty();
        response.Shapes.Should().HaveCount(queryResponse.Shapes.Count);
    }
}