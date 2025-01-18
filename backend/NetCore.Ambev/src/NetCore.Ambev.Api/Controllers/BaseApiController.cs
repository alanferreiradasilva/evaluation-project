using Microsoft.AspNetCore.Mvc;

namespace NetCore.Ambev.Api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
