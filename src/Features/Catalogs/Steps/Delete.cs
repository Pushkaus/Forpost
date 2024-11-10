using Forpost.Domain.Catalogs.Steps;
using Mediator;

namespace Forpost.Features.Catalogs.Steps;

internal sealed class DeleteStepCommandHandler : ICommandHandler<DeleteStepCommand>
{
    private readonly IStepDomainRepository _stepDomainRepository;

    public DeleteStepCommandHandler(IStepDomainRepository stepDomainRepository)
    {
        _stepDomainRepository = stepDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteStepCommand command, CancellationToken cancellationToken)
    {
        _stepDomainRepository.DeleteById(command.StepId);
        return Unit.ValueTask;
    }
}

public record DeleteStepCommand(Guid StepId) : ICommand;