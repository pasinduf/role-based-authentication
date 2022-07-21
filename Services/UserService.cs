using AutoMapper;
using RoleBasedAuthentication.Authorization;
using RoleBasedAuthentication.Models;
using RoleBasedAuthentication.Response;
using System.Collections.Generic;

namespace RoleBasedAuthentication.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<UserResponse> GetAllUsers()
        {
            var users = new List<User>()
            {
                new User{Id = 1, Email="",FirstName="fname1",LastName="lname1",SystemRole = new SystemRole{Id =1, Name ="Admin"}},
                new User{Id = 2, Email="",FirstName="fname2",LastName="lname2",SystemRole = new SystemRole{Id =1, Name ="Admin 2"}}
            };
            var result = _mapper.Map<List<UserResponse>>(users);
            return result;
        }
    }
}
