using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Contractors;
using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class GetAllContractorsQueryHandler :
    IQueryHandler<GetAllContractorsQuery, EntityPagedResult<ContractorModel>>
{
    private readonly IContractorReadRepository _contractorReadRepository;
    public GetAllContractorsQueryHandler(IContractorReadRepository contractorReadRepository)
    {
        _contractorReadRepository = contractorReadRepository;
    }

    public async ValueTask<EntityPagedResult<ContractorModel>> Handle(GetAllContractorsQuery request,
        CancellationToken cancellationToken) =>
        await _contractorReadRepository.GetAllAsync(request.Filter, cancellationToken); 
}
public sealed record GetAllContractorsQuery(ContractorFilter Filter) 
    : IQuery<EntityPagedResult<ContractorModel>>;