using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Webapi.Controllers
{
    [Authorize]
    [ApiController]
    public class BaseController : ControllerBase
    {
       
    }
}
