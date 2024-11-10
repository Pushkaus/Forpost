using Mediator;
using System.Threading;
using System.Threading.Tasks;
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
        _contractorDomainRepository.DeleteById(command.ContragentId);
        return Unit.ValueTask;
    }
}

public record DeleteContractorCommand(Guid ContragentId) : ICommand;