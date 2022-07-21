

using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthentication.Authorization;
using RoleBasedAuthentication.Exceptions;
using System.Linq;

namespace RoleBasedAuthentication.Controllers
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Get user id from token
        /// </summary>
        /// <returns></returns>
        protected int GetUserId()
        {
            int userId;
            string userIdString = User.Claims
                .SingleOrDefault(c => c.Type == Claims.UserId)?.Value;
            if (int.TryParse(userIdString, out userId))
            {
                return userId;
            }

            throw new ApiException(UserErrors.UserNotFound);
        }

    }
}
