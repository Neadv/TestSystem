using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Services
{
    public interface IAuthorizationService
    {
        Task<string> Authorize(string username, string password);
    }
}