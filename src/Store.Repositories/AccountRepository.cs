using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Store.Repositories;

public class AccountRepository: IAccountRepository
{
    private readonly ForpostContextPostgres _db;
    private readonly IPasswordHasher<Employee> _passwordHasher;
    private readonly IConfiguration _configuration;
    
    public AccountRepository(ForpostContextPostgres db, IConfiguration configuration, IPasswordHasher<Employee> passwordHasher)
    {
        _db = db;
        _configuration = configuration;
        _passwordHasher = passwordHasher;
    }
    
    public async Task<IActionResult> LoginAsync(string firstName, string lastName, string password)
    {
        var user = await _db.Employees.FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName);
        if (user == null)
            return new UnauthorizedResult();
        var role = await _db.Roles.FirstOrDefaultAsync(r => r.Id == user.RoleId);
        if (role == null)
            return new UnauthorizedResult();
        var roleEntity = role.Name;
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        
        string? token;
        if (passwordVerificationResult == PasswordVerificationResult.Success)
        {
            token = GenerateJwtToken(user, roleEntity);
        }
        else
        {
            return new UnauthorizedResult();
        }
        return new OkObjectResult(new { token });
    }

    public async Task<string> RegisterAsync(string firstName, string lastName, string? patronymic, string post, string role, string? email,
        string phoneNumber, string password, Guid userId)
    {
        if (await _db.Employees.AnyAsync(e => e.PhoneNumber == phoneNumber))
            return "Сотрудник с таким номером телефона уже зарегистрирован.";
    
        var roleEntity = await _db.Roles.Where(r => r.Name == role).FirstOrDefaultAsync();
        if (roleEntity == null)
            return "Не удается определить роль сотрудника.";

        var employee = new Employee(firstName, lastName, patronymic, post, roleEntity.Id, email,
            phoneNumber, userId);
                                
        employee.PasswordHash = _passwordHasher.HashPassword(employee, password);

        await _db.Employees.AddAsync(employee);
        await _db.SaveChangesAsync();

        return "Регистрация прошла успешно.";
    }
    
    private string GenerateJwtToken(Employee user, string roleName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, roleName)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}