using AutoMapper;
using Forpost.Domain.Catalogs.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCardSteps;

internal sealed class AddTechCardStepCommandHandler : ICommandHandler<TechCardStepCreateCommand, Guid>
{
    private readonly ITechCardStepDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddTechCardStepCommandHandler(ITechCardStepDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public ValueTask<Guid> Handle(TechCardStepCreateCommand command, CancellationToken cancellationToken)
    {
        var techCardStep = _mapper.Map<TechCardStep>(command);
        return ValueTask.FromResult(_domainRepository.Add(techCardStep));
    }
}

public record TechCardStepCreateCommand(Guid TechCardId, Guid StepId, int Number) : ICommand<Guid>;