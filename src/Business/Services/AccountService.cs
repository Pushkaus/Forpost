using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Accounts;
using Forpost.Common;
using Forpost.Common.Exceptions;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.Employee;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using EmployeeWithRoleModel = Forpost.Business.Models.Accounts.EmployeeWithRoleModel;
using ILogger = Serilog.ILogger;

namespace Forpost.Business.Services;

internal sealed class AccountService: IAccountService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IPasswordHasher<EmployeeWithRole> _passwordHasher;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly ILogger<Employee> _logger;

    public AccountService(IEmployeeRepository employeeRepository,
        IRoleRepository roleRepository,
        IPasswordHasher<EmployeeWithRole> passwordHasher,
        IConfiguration configuration,
        IMapper mapper,
        ILogger<Employee> logger)
    {
        _employeeRepository = employeeRepository;
        _roleRepository = roleRepository;
        _passwordHasher = passwordHasher;
        _configuration = configuration;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<string> LoginAsync(LoginUserModel model)
    {
        var user = _mapper.Map<EmployeeWithRole>(model);

        // При добавлении нового пользователя его пароль хэшируется с добавлением соли
        var employee = await _employeeRepository.GetAutorizedByUsername(user.FirstName, user.LastName);

        if (employee == null)
        {
            throw new UnauthorizedAccessException("Неверное имя пользователя или пароль.");
        }
        var verificationResult = _passwordHasher.VerifyHashedPassword(employee, employee.PasswordHash, model.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Неверное имя пользователя или пароль.");
        }
        _logger.LogInformation("Авторизовался {employee}", employee.LastName);
        var token = GenerateJwtToken(employee);
        return token;

    }

    public async Task RegisterAsync(RegisterUserModel model)
    {
        var user = _mapper.Map<Employee>(model);

        var role = await _roleRepository.GetByNameAsync(model.Role);
        
        role.EnsureFoundBy(x => role.Name, model.Role);
        
        user.RoleId = role.Id;
        
        // Хэширование пароля
        /*user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
        
        await _employeeRepository.AddAsync(user);*/
    }
    
    private string GenerateJwtToken(EmployeeWithRole user)
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
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}