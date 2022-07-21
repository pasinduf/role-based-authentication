
using Microsoft.Extensions.DependencyInjection;
using RoleBasedAuthentication.Services;

namespace RoleBasedAuthentication.Common
{
    public static class DependencyResolver
    {
        public static void BuildDependencyInjectionProvider(IServiceCollection services)
        {
            //register services
            services.AddScoped(typeof(IAuthenticateService), typeof(AuthenticateService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
        }
    }
}
