using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Common;
using Forpost.Domain.Catalogs.Employees;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Application.Auth;

//TODO: вынести в базовые классы маппер, логгер, конфигурацию
internal sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPasswordHasher<Employee> _passwordHasher;
    private readonly IMapper _mapper;
    private readonly ILogger<LoginUserCommandHandler> _logger;
    private readonly IConfiguration _configuration;

    public LoginUserCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper,
        IPasswordHasher<Employee> passwordHasher, ILogger<LoginUserCommandHandler> logger,
        IConfiguration configuration)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<EmployeeWithRoleModel>(command);

        // При добавлении нового пользователя его пароль хэшируется с добавлением соли
        var employee =
            await _employeeRepository.GetAuthorizedByUsernameAsync(user.FirstName, user.LastName, cancellationToken);

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
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.FirstName),
                new(ClaimTypes.Surname, user.LastName),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Role, user.RoleId.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public sealed record LoginUserCommand(string FirstName, string LastName, string Password) : IRequest<string>;