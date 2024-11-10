using Mediator;
using System.Threading;
using System.Threading.Tasks;
using Forpost.Domain.Catalogs.Employees;

namespace Forpost.Features.Catalogs.Employees;

internal sealed class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeDomainRepository _employeeDomainRepository;

    public DeleteEmployeeCommandHandler(IEmployeeDomainRepository employeeDomainRepository)
    {
        _employeeDomainRepository = employeeDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
    {
        _employeeDomainRepository.DeleteById(command.EmployeeId);
        return Unit.ValueTask;
    }
}

public record DeleteEmployeeCommand(Guid EmployeeId) : ICommand;