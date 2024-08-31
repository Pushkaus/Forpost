using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class GetAllContractorsQueryHandler :
    IQueryHandler<GetAllContractorsQuery, IReadOnlyCollection<Contractor>>
{
    private readonly IContractorDomainRepository _domainRepository;

    public GetAllContractorsQueryHandler(IContractorDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Contractor>> Handle(GetAllContractorsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllContractorsQuery : IQuery<IReadOnlyCollection<Contractor>>;