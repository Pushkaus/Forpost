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
        var passwordHash = _passwordHasher.HashPassword(request, request.Password);
        var role = await _roleRepository.GetByNameAsync(request.Role, cancellationToken);
        role.EnsureFoundBy(entity => entity.Name, request.Role);

        var registeredUser = Employee.Register(request.FirstName, request.LastName, request.Post, role!.Id, passwordHash,
            request.PhoneNumber, request.Patronymic, request.Email);

        _employeeRepository.Add(registeredUser);
    }
}

public sealed record RegisterUserCommand : IRequest
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? Patronymic { get; set; }
    public string Post { get; set; } = default!;
    public string Role { get; set; } = default!;
    public string? Email { get; set; }
    public string PhoneNumber { get; set; } = default!;
    public string Password { get; set; } = default!;
}