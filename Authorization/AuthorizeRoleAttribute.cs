

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RoleBasedAuthentication.Authorization
{
    public class AuthorizeRoleAttribute : ActionFilterAttribute
    {
        private readonly IEnumerable<ESystemRoles> _systemRoles;

        public AuthorizeRoleAttribute(params ESystemRoles[] systemRoles)
        {
            _systemRoles = systemRoles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (FiltersHelper.HasAllowAnonymous(context))
            {
                return;
            }

            var roles = context.HttpContext.User.Claims
                .Where(c => c.Type == Claims.UserRoles && Enum.TryParse(c.Value, out ESystemRoles _))
                .Select(c => Enum.Parse<ESystemRoles>(c.Value));

            if (!roles.Any())
            {
                // If no roles then we don't know this user at all
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                var wrongResult = new { reason = "You are not authorized. Please login again." };
                context.Result = new JsonResult(wrongResult);
                return;
            }
            if (!_systemRoles.Any(sr => roles.Contains(sr)))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                var wrongResult = new { reason = "Access forbidden" };
                context.Result = new JsonResult(wrongResult);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
