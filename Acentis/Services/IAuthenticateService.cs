using System.Threading.Tasks;

namespace Ascentis.Services
{
    public interface IAuthenticateService
    {
        Task<string> AuthenticateAsync(string email, string password);
    }
}
