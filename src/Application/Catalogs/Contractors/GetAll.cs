using Forpost.Domain.Catalogs.Contractors;
using MediatR;

namespace Forpost.Application.Catalogs.Contractors;

internal sealed class GetAllContractorsQueryHandler :
    IRequestHandler<GetAllContractorsQuery, IReadOnlyCollection<Contractor>>
{
    private readonly IContractorDomainRepository _domainRepository;

    public GetAllContractorsQueryHandler(IContractorDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<Contractor>> Handle(GetAllContractorsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllContractorsQuery : IRequest<IReadOnlyCollection<Contractor>>;