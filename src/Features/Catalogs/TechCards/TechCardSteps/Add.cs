using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.TechCardSteps;

internal sealed class AddTechCardStepCommandHandler : ICommandHandler<TechCardStepCreateCommand, Guid>
{
    private readonly ITechCardStepDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddTechCardStepCommandHandler(ITechCardStepDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public async ValueTask<Guid> Handle(TechCardStepCreateCommand command, CancellationToken cancellationToken)
    {
        var existingSteps = await _domainRepository.GetAllStepsByTechCardId(command.TechCardId, cancellationToken);

        var nextNumber = existingSteps.Any() ? existingSteps.Max(s => s.Number) + 1 : 1;

        var techCardStep = TechCardStep.Add(command.TechCardId, command.StepId, nextNumber);

        var addedStepId = _domainRepository.Add(techCardStep);

        return addedStepId;
    }
}

public record TechCardStepCreateCommand(Guid TechCardId, Guid StepId) : ICommand<Guid>;