using Forpost.Domain.Catalogs.Contractors;
using Mediator;

namespace Forpost.Features.Catalogs.Contractors;

internal sealed class GetAllContractorsQueryHandler :
    IQueryHandler<GetAllContractorsQuery, (IReadOnlyList<Contractor> Contractors, int TotalCount)>
{
    private readonly IContractorDomainRepository _domainRepository;

    public GetAllContractorsQueryHandler(IContractorDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyList<Contractor> Contractors, int TotalCount)> Handle(GetAllContractorsQuery request,
        CancellationToken cancellationToken) =>
        await _domainRepository.GetAllAsync(request.FilterExpression, request.FilterValues,
            cancellationToken, request.Skip, request.Limit); 
}
public sealed record GetAllContractorsQuery(string? FilterExpression, object?[]? FilterValues, int Skip, int Limit) 
    : IQuery<(IReadOnlyList<Contractor> Contractors, int TotalCount)>;