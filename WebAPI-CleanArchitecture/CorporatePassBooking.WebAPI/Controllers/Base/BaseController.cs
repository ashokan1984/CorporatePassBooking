using Microsoft.AspNetCore.Mvc;

namespace CorporatePassBooking.WebAPI.Controllers.Base
{
    [Route("api/[controller]/[Action]")]
    //[Authorize]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
