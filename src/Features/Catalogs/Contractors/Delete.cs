using Mediator;
using Forpost.Domain.Catalogs.Contractors;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class DeleteContractorCommandHandler : ICommandHandler<DeleteContractorCommand>
{
    private readonly IContractorDomainRepository _contractorDomainRepository;

    public DeleteContractorCommandHandler(IContractorDomainRepository contractorDomainRepository)
    {
        _contractorDomainRepository = contractorDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteContractorCommand command, CancellationToken cancellationToken)
    {
        _contractorDomainRepository.DeleteById(command.ContractorId);
        return Unit.ValueTask;
    }
}

public record DeleteContractorCommand(Guid ContractorId) : ICommand;