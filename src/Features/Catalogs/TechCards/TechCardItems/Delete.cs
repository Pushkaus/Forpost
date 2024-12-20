using Forpost.Domain.Catalogs.TechCards.TechCardItems;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardItems;

internal sealed class DeleteTechCardItemCommandHandler : ICommandHandler<DeleteTechCardItemCommand>
{
    private readonly ITechCardItemDomainRepository _techCardItemDomainRepository;

    public DeleteTechCardItemCommandHandler(ITechCardItemDomainRepository techCardItemDomainRepository)
    {
        _techCardItemDomainRepository = techCardItemDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteTechCardItemCommand command, CancellationToken cancellationToken)
    {
        _techCardItemDomainRepository.DeleteById(command.TechCardItemId);
        return Unit.ValueTask;
    }
}

public record DeleteTechCardItemCommand(Guid TechCardItemId) : ICommand;