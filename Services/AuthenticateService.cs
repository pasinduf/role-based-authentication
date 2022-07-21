

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RoleBasedAuthentication.Authorization;
using RoleBasedAuthentication.Models;
using RoleBasedAuthentication.Requests;
using RoleBasedAuthentication.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RoleBasedAuthentication.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IConfiguration _config;
        private string _jwtKey;

        public AuthenticateService(IConfiguration config)
        {
            _config = config;
            SetupConfiguration();
        }

        private void SetupConfiguration()
        {
            _jwtKey = _config["AppSetting:JwtKey"];
        }

        public async Task<LoginResponse> AdminLogin(LoginRequest authenticateRequest)
        {
            var loginResponse = new LoginResponse();
            var user = new User
            {
                Id =1,
                FirstName = "Admin",
                LastName = "123",
                Email = "admin@gmail.com",
                SystemRole = new SystemRole { Id = (int)ESystemRoles.Admin, Name = "Admin" }
            };
            var userRoles = new List<string>() { ESystemRoles.Admin.ToString()};
            loginResponse.Token = GenerateToken(user, userRoles);
            loginResponse.User = user;
            return loginResponse;
        }

        public async Task<LoginResponse> UserLogin(LoginRequest authenticateRequest)
        {
            var loginResponse = new LoginResponse();
            var user = new User
            {
                Id = 2,
                FirstName = "User",
                LastName = "456",
                Email = "user@gmail.com",
                SystemRole = new SystemRole { Id = (int)ESystemRoles.User, Name = "User" }
            };
            var userRoles = new List<string>() { ESystemRoles.User.ToString() };
            loginResponse.Token = GenerateToken(user, userRoles);
            loginResponse.User = user;
            return loginResponse;
        }

        private string GenerateToken(User user, List<string> userRoles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtKey);
            string roles = JsonConvert.SerializeObject(userRoles);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(Claims.UserId, Convert.ToString(user.Id)),
                    new Claim(Claims.UserRoles, roles, JsonClaimValueTypes.JsonArray),
                }),
                Expires = DateTime.Now.AddDays(int.Parse(_config["AppSetting:TokenExpiresInDays"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

       
    }

   
}
