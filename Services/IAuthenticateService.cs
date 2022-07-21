

using RoleBasedAuthentication.Requests;
using RoleBasedAuthentication.Response;
using System.Threading.Tasks;

namespace RoleBasedAuthentication.Services
{
    public interface IAuthenticateService
    {
        Task<LoginResponse> AdminLogin(LoginRequest authenticateRequest);
        Task<LoginResponse> UserLogin(LoginRequest authenticateRequest);
    }
}
