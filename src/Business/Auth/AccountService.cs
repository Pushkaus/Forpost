using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Forpost.Business.Auth.Commands;
using Forpost.Common;
using Forpost.EventBus;
using Forpost.Store.Entities.Catalog;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Models.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Forpost.Business.Auth;

internal sealed class AccountService : BusinessService, IAccountService
{
    private readonly IPasswordHasher<EmployeeWithRoleModel> _passwordHasher;

    public AccountService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider, IPasswordHasher<EmployeeWithRoleModel> passwordHasher)
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
        _passwordHasher = passwordHasher;
    }

    public async Task<string> LoginAsync(LoginUserCommand model, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<EmployeeWithRoleModel>(model);
        
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

    public async Task RegisterAsync(RegisterUserCommand model, CancellationToken cancellationToken)
    {
        var user = Mapper.Map<EmployeeEntity>(model);

        var role = await DbUnitOfWork.RoleRepository.GetByNameAsync(model.Role, cancellationToken);

        role.EnsureFoundBy(x => x.Name, model.Role);

        user.RoleId = role!.Id;

        // Хэширование пароля
        /*user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

        await _employeeRepository.AddAsync(user);*/
    }

    private string GenerateJwtToken(EmployeeWithRoleModel user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"] ?? throw new ArgumentException());
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