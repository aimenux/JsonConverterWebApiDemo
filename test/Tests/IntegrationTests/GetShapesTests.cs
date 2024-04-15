namespace Tests.IntegrationTests;

[Collection(IntegrationCollectionFixture.CollectionName)]
public class GetShapesTests
{
    private readonly IntegrationWebApplicationFactory _factory;

    public GetShapesTests(IntegrationWebApplicationFactory factory)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
    }

    [Theory]
    [InlineData("api/v1/shapes")]
    public async Task Should_Get_Shapes_Returns_Ok(string route)
    {
        // arrange
        var client = _factory.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}