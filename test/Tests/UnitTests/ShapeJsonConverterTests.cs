namespace Tests.UnitTests;

public class ShapeJsonConverterTests
{
    private static readonly IFixture Fixture = new Fixture();
    
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters = { new ShapeJsonConverter() }
    };

    [Fact]
    public void Should_Serialize_Shapes_With_CamelCase()
    {
        // arrange

        var circles = Fixture
            .Build<CircleDto>()
            .With(x => x.Type, nameof(ShapeType.Circle))
            .CreateMany();
        
        var shapes = new List<IShapeDto>(circles);

        // act
        var json = JsonSerializer.Serialize(shapes, Options);

        // assert
        json.Should().NotBeNullOrEmpty();
        json.Should().BeValidCamelCaseJson<ICollection<CircleDto>>(items => items.All(IsValidCircleDto));
    }

    [Fact]
    public void Given_UnexpectedType_Then_Should_Throw_ArgumentOutOfRangeException()
    {
        // arrange
        var shapes = new List<IShapeDto>(Fixture.CreateMany<FakeShapeDto>());

        // act
        var jsonFunc = () => JsonSerializer.Serialize(shapes, Options);

        // assert
        jsonFunc.Should().Throw<ArgumentOutOfRangeException>();
    }
    
    private static bool IsValidCircleDto(CircleDto circleDto) => string.Equals(circleDto.Type, nameof(ShapeType.Circle)); 

    private sealed record FakeShapeDto(Guid Id, string Type) : IShapeDto;
}