
using RoleBasedAuthentication.Response;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Services
{
    public interface IUserService
    {
        List<UserResponse> GetAllUsers();
    }
}
