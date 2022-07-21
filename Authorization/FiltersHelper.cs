using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace RoleBasedAuthentication.Authorization
{
    public static class FiltersHelper
    {
        public static bool HasAllowAnonymous(FilterContext context)
        {
            return context?.HttpContext?.GetEndpoint()?.Metadata?.GetMetadata<IAllowAnonymous>() != null || (context?.Filters.Any(f => f is AllowAnonymousFilter) ?? false);
        }
    }
}
