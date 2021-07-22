using OnlineTestSystem.Api.Models;

namespace OnlineTestSystem.Api.Services
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}