using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forpost.Web.Contracts.Authentication
{
    [ApiController]
    [Route("api/v1/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] string userName, [FromQuery] string userPassword, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Received login request: Name={userName}, Password={userPassword}");
            if (userName == null || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPassword))
            {
                return BadRequest("Invalid client request");
            }
            var result = await _authenticationService.Login(userName, userPassword, cancellationToken);
            return result;
        }
    }

}
