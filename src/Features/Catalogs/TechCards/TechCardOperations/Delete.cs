using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardOperations;

internal sealed class DeleteTechCardStepCommandHandler : ICommandHandler<DeleteTechCardOperationCommand>
{
    private readonly ITechCardOperationDomainRepository _techCardOperationDomainRepository;

    public DeleteTechCardStepCommandHandler(ITechCardOperationDomainRepository techCardOperationDomainRepository)
    {
        _techCardOperationDomainRepository = techCardOperationDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteTechCardOperationCommand command, CancellationToken cancellationToken)
    {
        _techCardOperationDomainRepository.DeleteById(command.TechCardStepId);
        return Unit.ValueTask;
    }
}

public record DeleteTechCardOperationCommand(Guid TechCardStepId) : ICommand;