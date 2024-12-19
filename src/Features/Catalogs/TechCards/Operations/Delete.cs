using Forpost.Domain.Catalogs.TechCards.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Operations;

internal sealed class DeleteOperationCommandHandler: ICommandHandler<DeleteOperationCommand>
{
    private readonly IOperationDomainRepository _operationDomainRepository;

    public DeleteOperationCommandHandler(IOperationDomainRepository operationDomainRepository)
    {
        _operationDomainRepository = operationDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteOperationCommand command, CancellationToken cancellationToken)
    {
        _operationDomainRepository.DeleteById(command.Id);
        return ValueTask.FromResult(Unit.Value);
    }
}
public record DeleteOperationCommand(Guid Id) : ICommand;