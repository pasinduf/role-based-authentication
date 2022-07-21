

using AutoMapper;
using RoleBasedAuthentication.Models;
using RoleBasedAuthentication.Response;

namespace RoleBasedAuthentication.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
