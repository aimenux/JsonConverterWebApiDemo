namespace Api.Presentation;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class BaseController : ControllerBase
{
    protected string ApiVersion => HttpContext.GetRequestedApiVersion()?.ToString() ?? ApiConstants.Versions.V1;
}