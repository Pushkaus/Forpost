using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardOperations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardOperations;

internal sealed class AddTechCardStepCommandHandler : ICommandHandler<TechCardOperationCreateCommand, Guid>
{
    private readonly ITechCardOperationDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddTechCardStepCommandHandler(ITechCardOperationDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Guid> Handle(TechCardOperationCreateCommand command, CancellationToken cancellationToken)
    {
        var existingSteps = await _domainRepository.GetAllOperationsByTechCardId(command.TechCardId, cancellationToken);

        var nextNumber = existingSteps.Any() ? existingSteps.Max(s => s.Number) + 1 : 1;

        var techCardStep = TechCardOperation.Add(command.TechCardId, command.OperationId, nextNumber);

        var addedStepId = _domainRepository.Add(techCardStep);

        return addedStepId;
    }
}

public record TechCardOperationCreateCommand(Guid TechCardId, Guid OperationId) : ICommand<Guid>;