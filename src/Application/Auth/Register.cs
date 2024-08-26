using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Common;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Roles;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Application.Auth;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterUserCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IPasswordHasher<RegisterUserCommand> _passwordHasher;
    private readonly IRoleRepository _roleRepository;

    public RegisterCommandHandler(IEmployeeRepository employeeRepository,
        IPasswordHasher<RegisterUserCommand> passwordHasher,
        IRoleRepository roleRepository)
    {
        _employeeRepository = employeeRepository;
        _passwordHasher = passwordHasher;
        _roleRepository = roleRepository;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _passwordHasher.HashPassword(request, request.Model.Password);
        var role = await _roleRepository.GetByNameAsync(request.Model.Role, cancellationToken);
        role.EnsureFoundBy(entity => entity.Name, request.Model.Role);

        var registeredUser = Employee.Register(request.Model.FirstName, request.Model.LastName, request.Model.Post,
            role!.Id, passwordHash,
            request.Model.PhoneNumber, request.Model.Patronymic, request.Model.Email);

        _employeeRepository.Add(registeredUser);
    }
}

public sealed record RegisterUserCommand(RegisterUserModel Model) : IRequest;
