using Microsoft.AspNetCore.Identity;
using OnlineTestSystem.Api.Models;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthorizationService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Authorize(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                return _tokenService.GenerateToken(user);
            }
            return null;
        }
    }
}
