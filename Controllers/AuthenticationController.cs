using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthentication.Requests;
using RoleBasedAuthentication.Response;
using RoleBasedAuthentication.Services;
using System;
using System.Threading.Tasks;

namespace RoleBasedAuthentication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [Route("admin-login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginRequest>> AdminLogin([FromBody] LoginRequest request)
        {
            try
            {
                var loginResult = await _authenticateService.AdminLogin(request);
                return Ok(loginResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("user-login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginRequest>> UserLogin([FromBody] LoginRequest request)
        {
            try
            {
                var loginResult = await _authenticateService.UserLogin(request);
                return Ok(loginResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
