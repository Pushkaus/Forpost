using Forpost.Application.Contracts.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class GetContractorByIdQueryHandler : IQueryHandler<GetContractorByIdQuery, ContractorModel?>
{
    private readonly IContractorReadRepository _contractorReadRepository;
    public GetContractorByIdQueryHandler(IContractorReadRepository contractorReadRepository)
    {
        _contractorReadRepository = contractorReadRepository;
    }

    public async ValueTask<ContractorModel?> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _contractorReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}

public sealed record GetContractorByIdQuery(Guid Id) : IQuery<ContractorModel?>;