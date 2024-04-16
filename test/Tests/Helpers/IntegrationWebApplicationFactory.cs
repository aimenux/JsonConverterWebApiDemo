namespace Tests.Helpers;

public class IntegrationWebApplicationFactory : WebApplicationFactory<Startup>
{
    private readonly IShapesRepository _shapesRepository = Substitute.For<IShapesRepository>();

    public HttpClient CreateClientWithShapes(params IShape[] shapes)
    {
        _shapesRepository
            .GetShapesAsync(Arg.Any<CancellationToken>())
            .Returns(shapes);

        return CreateClient();
    }
    
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddDebug().AddConsole();
        });
        
        builder.ConfigureAppConfiguration((_, _) =>
        {
        });

        builder.ConfigureTestServices(services =>
        {
        });
    }
}