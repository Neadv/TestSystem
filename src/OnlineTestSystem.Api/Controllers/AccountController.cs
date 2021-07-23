using Microsoft.AspNetCore.Mvc;
using OnlineTestSystem.Api.Models.Dto;
using OnlineTestSystem.Api.Services;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("token")]
        public async Task<ActionResult> GetToken(UserLoginModel userLogin)
        {
            var token = await _authorizationService.Authorize(userLogin.Username, userLogin.Password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return BadRequest(new { Error = "Username or password is incorrect."});
        }
    }
}
