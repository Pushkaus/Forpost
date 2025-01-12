using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Common;
using Forpost.Domain.Catalogs.Employees;
using Mediator;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Features.Auth;

internal sealed class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, string>
{
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IPasswordHasher<Employee> _passwordHasher;
    private readonly IMapper _mapper;
    private readonly ILogger<LoginUserCommandHandler> _logger;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IEmployeeDomainRepository employeeDomainRepository, IMapper mapper,
        IPasswordHasher<Employee> passwordHasher, ILogger<LoginUserCommandHandler> logger,
        IConfiguration configuration)
    {
        _employeeDomainRepository = employeeDomainRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _logger = logger;
        _configuration = configuration;
    }

    public async ValueTask<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<EmployeeWithRoleModel>(command);

        var employee =
            await _employeeDomainRepository.GetAuthorizedByUsernameAsync(user.FirstName, user.LastName, cancellationToken);

        if (employee == null) throw ForpostErrors.Validation("Неверное имя пользователя или пароль.");
        
        var verificationResult = _passwordHasher.VerifyHashedPassword(employee, employee.PasswordHash, command.Password);
        
        if (verificationResult == PasswordVerificationResult.Failed)
            throw ForpostErrors.Validation("Неверное имя пользователя или пароль.");
        
        _logger.LogInformation("Авторизовался {employee}", employee.LastName);
        var token = GenerateJwtToken(employee);
        return token;
    }

    private string GenerateJwtToken(Employee user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? throw new ArgumentException());
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            ]),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public sealed record LoginUserCommand(string FirstName, string LastName, string Password) : ICommand<string>;