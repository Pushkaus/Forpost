using AutoMapper;
using Forpost.Common;
using Forpost.Domain.Catalogs.Steps;
using Forpost.Domain.Catalogs.TechCards.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Steps;

internal sealed class UpdateStepCommandHandler : ICommandHandler<UpdateStepCommand>
{
    private readonly IStepDomainRepository _stepDomainRepository;
    private readonly IMapper _mapper;
    public UpdateStepCommandHandler(IStepDomainRepository stepDomainRepository, IMapper mapper)
    {
        _stepDomainRepository = stepDomainRepository;
        _mapper = mapper;
    }
    public async ValueTask<Unit> Handle(UpdateStepCommand command, CancellationToken cancellationToken)
    {
        var existingStep = await _stepDomainRepository.GetByIdAsync(command.Id, cancellationToken);
        
        if (existingStep == null) throw ForpostErrors.NotFound<Step>(command.Id);
        
        existingStep = Step.Create(command.OperationId, command.Description, command.Duration);

        _stepDomainRepository.Update(existingStep);

        return Unit.Value;
    }
}
public record UpdateStepCommand(
    Guid Id,
    Guid OperationId,
    string? Description,
    TimeSpan Duration
    ) : ICommand;