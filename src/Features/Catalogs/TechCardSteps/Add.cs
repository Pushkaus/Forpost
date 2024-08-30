using AutoMapper;
using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardSteps;

internal sealed class AddTechCardStepCommandHandler : IRequestHandler<TechCardStepCreateCommand, Guid>
{
    private readonly ITechCardStepDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public AddTechCardStepCommandHandler(ITechCardStepDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(TechCardStepCreateCommand command, CancellationToken cancellationToken)
    {
        var techCardStep = _mapper.Map<TechCardStep>(command);
        return Task.FromResult(_domainRepository.Add(techCardStep));
    }
}

public record TechCardStepCreateCommand(Guid TechCardId, Guid StepId, int Number) : IRequest<Guid>;