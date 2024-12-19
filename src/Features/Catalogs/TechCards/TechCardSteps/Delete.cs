using Forpost.Domain.Catalogs.TechCards.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardSteps;

internal sealed class DeleteTechCardStepCommandHandler : ICommandHandler<DeleteTechCardStepCommand>
{
    private readonly ITechCardStepDomainRepository _techCardStepDomainRepository;

    public DeleteTechCardStepCommandHandler(ITechCardStepDomainRepository techCardStepDomainRepository)
    {
        _techCardStepDomainRepository = techCardStepDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteTechCardStepCommand command, CancellationToken cancellationToken)
    {
        _techCardStepDomainRepository.DeleteById(command.TechCardStepId);
        return Unit.ValueTask;
    }
}

public record DeleteTechCardStepCommand(Guid TechCardStepId) : ICommand;