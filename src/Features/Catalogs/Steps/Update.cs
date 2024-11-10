using AutoMapper;
using Forpost.Domain.Catalogs.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class UpdateStepCommandHandler : ICommandHandler<UpdateStepCommand>
{
    private readonly IStepDomainRepository _stepDomainRepository;
    private readonly IMapper _mapper;
    public UpdateStepCommandHandler(IStepDomainRepository stepDomainRepository, IMapper mapper)
    {
        _stepDomainRepository = stepDomainRepository;
        _mapper = mapper;
    }
    public ValueTask<Unit> Handle(UpdateStepCommand command, CancellationToken cancellationToken)
    {
        _stepDomainRepository.Update(_mapper.Map<Step>(command));
        return ValueTask.FromResult(Unit.Value);
    }
}
public record UpdateStepCommand(
    Guid StepId,
    Guid TechCardId,
    Guid OperationId,
    string? Description,
    TimeSpan Duration,
    decimal Cost,
    UnitOfMeasure UnitOfMeasure) : ICommand;