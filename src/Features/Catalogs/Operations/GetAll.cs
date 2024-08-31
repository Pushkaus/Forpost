using Forpost.Domain.Catalogs.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.Operations;

internal sealed class GetAllOperationsQueryHandler :
    IQueryHandler<GetAllOperationsQuery, IReadOnlyCollection<Operation>>
{
    private readonly IOperationDomainRepository _domainRepository;

    public GetAllOperationsQueryHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Operation>> Handle(GetAllOperationsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllOperationsQuery : IQuery<IReadOnlyCollection<Operation>>;