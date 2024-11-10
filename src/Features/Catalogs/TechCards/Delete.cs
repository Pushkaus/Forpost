using Forpost.Domain.Catalogs.TechCards;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards;

internal sealed class DeleteTechCardCommandHandler : ICommandHandler<DeleteTechCardCommand>
{
    private readonly ITechCardDomainRepository _techCardDomainRepository;

    public DeleteTechCardCommandHandler(ITechCardDomainRepository techCardDomainRepository)
    {
        _techCardDomainRepository = techCardDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteTechCardCommand command, CancellationToken cancellationToken)
    {
        _techCardDomainRepository.DeleteById(command.TechCardId);
        return Unit.ValueTask;
    }
}

public record DeleteTechCardCommand(Guid TechCardId) : ICommand;