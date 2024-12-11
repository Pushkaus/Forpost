using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors.ContractorRepresentatives;

internal sealed class DeleteByIdCommandHandler: ICommandHandler<DeleteByIdCommand>
{
    private readonly IContractorRepresentativesDomainRepository _contractorRepresentativesDomainRepository;

    public DeleteByIdCommandHandler(IContractorRepresentativesDomainRepository contractorRepresentativesDomainRepository)
    {
        _contractorRepresentativesDomainRepository = contractorRepresentativesDomainRepository;
    }

    public ValueTask<Unit> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
    {
         _contractorRepresentativesDomainRepository.DeleteById(command.Id);
         return new ValueTask<Unit>(Unit.Value);
    }
}
public record DeleteByIdCommand(Guid Id): ICommand;