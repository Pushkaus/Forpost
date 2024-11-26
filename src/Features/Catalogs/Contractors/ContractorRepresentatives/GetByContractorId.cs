using Forpost.Application.Contracts.Catalogs.Contractors.ContractorRepresentatives;
using Forpost.Domain.Catalogs.Contractors.ContractorRepresentatives;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors.ContractorRepresentatives;

internal sealed class
    GetByContractorIdQueryHandler : IQueryHandler<GetByContractorIdQuery, IReadOnlyCollection<ContractorRepresentative>>
{
    private readonly IContractorRepresentativeReadRepository _contractorRepresentativeReadRepository;

    public GetByContractorIdQueryHandler(IContractorRepresentativeReadRepository contractorRepresentativeReadRepository)
    {
        _contractorRepresentativeReadRepository = contractorRepresentativeReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<ContractorRepresentative>> Handle(GetByContractorIdQuery query,
        CancellationToken cancellationToken)
    {
        return await _contractorRepresentativeReadRepository.GetByContractorIdAsync(query.ContractorId,
            cancellationToken);
    }
}
public record GetByContractorIdQuery(Guid ContractorId) : IQuery<IReadOnlyCollection<ContractorRepresentative>>;