using FluentValidation;
using Forpost.Application.Contracts.Catalogs.Employees;
using Forpost.Common;
using Forpost.Domain.Catalogs.Employees;
using Forpost.Domain.Catalogs.Roles;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Features.Auth;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
{
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IPasswordHasher<RegisterUserCommand> _passwordHasher;
    private readonly IRoleDomainRepository _roleDomainRepository;
    private readonly IValidator<RegisterUserCommand> _validator;
    
    public RegisterCommandHandler(IEmployeeDomainRepository employeeDomainRepository,
        IPasswordHasher<RegisterUserCommand> passwordHasher,
        IRoleDomainRepository roleDomainRepository, IValidator<RegisterUserCommand> validator)
    {
        _employeeDomainRepository = employeeDomainRepository;
        _passwordHasher = passwordHasher;
        _roleDomainRepository = roleDomainRepository;
        _validator = validator;
    }

    public async ValueTask<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        
        var passwordHash = _passwordHasher.HashPassword(request, request.Model.Password);
        var role = await _roleDomainRepository.GetByNameAsync(request.Model.Role, cancellationToken);
        role.EnsureFoundBy(entity => entity.Name, request.Model.Role);
        
        var registeredUser = Employee.Register(request.Model.FirstName, request.Model.LastName, request.Model.Post,
            role!.Id, passwordHash,
            request.Model.PhoneNumber, request.Model.Patronymic, request.Model.Email);

        var employeeId = _employeeDomainRepository.Add(registeredUser);
        
        return employeeId;
    }
}

public sealed record RegisterUserCommand(RegisterUserModel Model) : ICommand<Guid>;
