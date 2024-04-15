using Api.Presentation.V1.GetShapes;

namespace Api.Presentation.V1;

[ApiVersion(ApiConstants.Versions.V1)]
public class ShapesController : BaseController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    private readonly ILogger<ShapesController> _logger;

    public ShapesController(ISender sender, IMapper mapper, ILogger<ShapesController> logger)
    {
        _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [SwaggerOperation(nameof(GetShapes))]
    public async Task<IActionResult> GetShapes(CancellationToken cancellationToken)
    {
        using var _ = _logger.BeginScope("Get shapes");
        var request = new GetShapesRequest();
        var query = _mapper.Map<GetShapesQuery>(request);
        var queryResponse = await _sender.Send(query, cancellationToken);
        var apiResponse = _mapper.Map<GetShapesResponse>(queryResponse);
        return Ok(apiResponse);
    }
}