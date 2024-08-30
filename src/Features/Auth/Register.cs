using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Common;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Application.Auth;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterUserCommand>
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

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasher.HashPassword(request, request.Model.Password);
        var role = await _roleDomainRepository.GetByNameAsync(request.Model.Role, cancellationToken);
        role.EnsureFoundBy(entity => entity.Name, request.Model.Role);

        var registeredUser = Employee.Register(request.Model.FirstName, request.Model.LastName, request.Model.Post,
            role!.Id, passwordHash,
            request.Model.PhoneNumber, request.Model.Patronymic, request.Model.Email);

        _employeeDomainRepository.Add(registeredUser);
    }
}

public sealed record RegisterUserCommand(RegisterUserModel Model) : IRequest;
