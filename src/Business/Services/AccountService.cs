using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Models.Accounts;
using Forpost.Common;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Models.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Business.Services;

internal sealed class AccountService : BaseBusinessService
{
    private readonly IPasswordHasher<EmployeeWithRole> _passwordHasher;

    public AccountService(IDbUnitOfWork dbUnitOfWork,
        ILogger<AccountService> logger,
        IMapper mapper,
        TimeProvider timeProvider,
        IConfiguration configuration,
        IPasswordHasher<EmployeeWithRole> passwordHasher) : base(dbUnitOfWork, logger, mapper, configuration,
        timeProvider)
    {
        _passwordHasher = passwordHasher;
    }

    public async Task<string> LoginAsync(LoginUserModel model, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<EmployeeWithRole>(model);

        // При добавлении нового пользователя его пароль хэшируется с добавлением соли
        var employee =
            await DbUnitOfWork.EmployeeRepository.GetAutorizedByUsernameAsync(user.FirstName, user.LastName, cancellationToken);

        if (employee == null) throw ForpostErrors.Validation("Неверное имя пользователя или пароль.");
        var verificationResult = _passwordHasher.VerifyHashedPassword(employee, employee.PasswordHash, model.Password);

        if (verificationResult == PasswordVerificationResult.Failed)
            throw ForpostErrors.Validation("Неверное имя пользователя или пароль.");
        Logger.LogInformation("Авторизовался {employee}", employee.LastName);
        var token = GenerateJwtToken(employee);
        return token;
    }

    public async Task RegisterAsync(RegisterUserModel model, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<Employee>(model);

        var role = await DbUnitOfWork.RoleRepository.GetByNameAsync(model.Role, cancellationToken);

        role.EnsureFoundBy(x => role.Name, model.Role);

        user.RoleId = role.Id;

        // Хэширование пароля
        /*user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

        await _employeeRepository.AddAsync(user);*/
    }

    private string GenerateJwtToken(EmployeeWithRole user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, user.FirstName),
                new(ClaimTypes.Surname, user.LastName),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddDays(30),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}