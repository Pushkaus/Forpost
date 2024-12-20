using AutoMapper;
using Forpost.Domain.Catalogs.TechCards.TechCardSteps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCardSteps;

internal sealed class UpdateTechCardStepCommandHandler: ICommandHandler<UpdateTechCardStepCommand>
{
    private readonly ITechCardStepDomainRepository _techCardStepRepository;
    private readonly IMapper _mapper;
    
    public UpdateTechCardStepCommandHandler(ITechCardStepDomainRepository techCardStepRepository, IMapper mapper)
    {
        _techCardStepRepository = techCardStepRepository;
        _mapper = mapper;
    }

    public ValueTask<Unit> Handle(UpdateTechCardStepCommand command, CancellationToken cancellationToken)
    {
        _techCardStepRepository.Update(_mapper.Map<TechCardStep>(command));
        return ValueTask.FromResult(Unit.Value);
    }
}
public record UpdateTechCardStepCommand(Guid Id, Guid TechCardId, Guid StepId, int Number) : ICommand;