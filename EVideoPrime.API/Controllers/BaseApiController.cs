using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EVideoPrime.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}
