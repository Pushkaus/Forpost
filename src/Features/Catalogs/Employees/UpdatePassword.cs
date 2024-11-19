using Forpost.Domain.Catalogs.Employees;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace Forpost.Features.Catalogs.Employees;

internal sealed class UpdatePasswordCommandHandler : ICommandHandler<UpdatePasswordCommand>
{
    private readonly IEmployeeDomainRepository _employeeDomainRepository;
    private readonly IPasswordHasher<Employee> _passwordHasher;

    public UpdatePasswordCommandHandler(IEmployeeDomainRepository employeeDomainRepository,
        IPasswordHasher<Employee> passwordHasher)
    {
        _employeeDomainRepository = employeeDomainRepository;
        _passwordHasher = passwordHasher;
    }

    public async ValueTask<Unit> Handle(UpdatePasswordCommand command, CancellationToken cancellationToken)
    {
        var employee = await _employeeDomainRepository.GetByIdAsync(command.Id, cancellationToken);

        var newPasswordHash = _passwordHasher.HashPassword(employee, command.NewPassword);
        
        employee.SetNewPassword(newPasswordHash);
        
        _employeeDomainRepository.Update(employee);
        
        return Unit.Value;
    }
}

public record UpdatePasswordCommand(Guid Id, string NewPassword) : ICommand;