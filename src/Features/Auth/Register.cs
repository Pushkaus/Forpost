using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Common;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Roles;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Features.Auth;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IPasswordHasher<RegisterUserCommand> _passwordHasher;
    private readonly IRoleDomainRepository _roleDomainRepository;

    public RegisterCommandHandler(IEmployeeDomainRepository employeeDomainRepository,
        IPasswordHasher<RegisterUserCommand> passwordHasher,
        IRoleDomainRepository roleDomainRepository)
    {
        _employeeDomainRepository = employeeDomainRepository;
        _passwordHasher = passwordHasher;
        _roleDomainRepository = roleDomainRepository;
    }

    public async ValueTask<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasher.HashPassword(request, request.Model.Password);
        var role = await _roleDomainRepository.GetByNameAsync(request.Model.Role, cancellationToken);
        role.EnsureFoundBy(entity => entity.Name, request.Model.Role);

        var registeredUser = Employee.Register(request.Model.FirstName, request.Model.LastName, request.Model.Post,
            role!.Id, passwordHash,
            request.Model.PhoneNumber, request.Model.Patronymic, request.Model.Email);

        _employeeDomainRepository.Add(registeredUser);
        
        return Unit.Value;
    }
}

public sealed record RegisterUserCommand(RegisterUserModel Model) : ICommand;
