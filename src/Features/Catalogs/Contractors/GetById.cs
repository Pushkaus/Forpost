using Forpost.Common;
using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class GetContractorByIdQueryHandler : IQueryHandler<GetContractorByIdQuery, Contractor>
{
    private readonly IContractorDomainRepository _domainRepository;

    public GetContractorByIdQueryHandler(IContractorDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Contractor> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
    {
        var contractor = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return contractor.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetContractorByIdQuery(Guid Id) : IQuery<Contractor>;