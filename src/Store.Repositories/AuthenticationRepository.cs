using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forpost.Store.Repositories
{
    public class AuthenticationRepository: IAuthenticationRepository
    {
        private readonly PostgresContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthenticationRepository(PostgresContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<IActionResult> Login(string userName, string userPassword, CancellationToken cancellationToken)
        {
            var dbUser = await _dbContext.Staff.FirstOrDefaultAsync(
                u => u.Name == userName && u.Password == userPassword,
                cancellationToken);

            if (dbUser == null)
                return new UnauthorizedResult();

            var token = GenerateJwtToken(dbUser);
            return new OkObjectResult(new { token });
        }


        private string GenerateJwtToken(Staff user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Post)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
