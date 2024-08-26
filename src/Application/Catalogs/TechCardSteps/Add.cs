using AutoMapper;
using Forpost.Domain.Catalogs.TechCardSteps;
using MediatR;

namespace Forpost.Application.Catalogs.TechCardSteps;

internal sealed class AddTechCardStepCommandHandler : IRequestHandler<TechCardStepCreateCommand, Guid>
{
    private readonly ITechCardStepRepository _repository;
    private readonly IMapper _mapper;

    public AddTechCardStepCommandHandler(ITechCardStepRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<Guid> Handle(TechCardStepCreateCommand command, CancellationToken cancellationToken)
    {
        var techCardStep = _mapper.Map<TechCardStep>(command);
        return Task.FromResult(_repository.Add(techCardStep));
    }
}

public record TechCardStepCreateCommand(Guid TechCardId, Guid StepId, int Number) : IRequest<Guid>;