using Forpost.Common;
using Forpost.Domain.Catalogs.TechCards.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Operations;

internal sealed class ChangeDescriptionOperationCommandHandler : ICommandHandler<ChangeDescriptionOperationCommand>
{
    private readonly IOperationDomainRepository _operationDomainRepository;

    public ChangeDescriptionOperationCommandHandler(IOperationDomainRepository operationDomainRepository)
    {
        _operationDomainRepository = operationDomainRepository;
    }

    public async ValueTask<Unit> Handle(ChangeDescriptionOperationCommand command, CancellationToken cancellationToken)
    {
        var operation = await _operationDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        if (operation == null) throw ForpostErrors.NotFound<Operation>(command.Id);
        operation.ChangeDescription(command.Description);
        _operationDomainRepository.Update(operation);
        return Unit.Value;
    }
}

public record ChangeDescriptionOperationCommand(Guid Id, string Description) : ICommand;