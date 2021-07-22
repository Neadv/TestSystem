using Microsoft.AspNetCore.Mvc;

namespace OnlineTestSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
