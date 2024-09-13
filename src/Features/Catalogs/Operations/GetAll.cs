using Forpost.Domain.Catalogs.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.Operations;

internal sealed class GetAllOperationsQueryHandler :
    IQueryHandler<GetAllOperationsQuery, (IReadOnlyCollection<Operation> Operations, int TotalCount)>
{
    private readonly IOperationDomainRepository _domainRepository;

    public GetAllOperationsQueryHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<Operation> Operations, int TotalCount)> Handle(GetAllOperationsQuery request,
        CancellationToken cancellationToken)
    {
        var operations = await _domainRepository.GetAllAsync(cancellationToken);
        return operations;
    }
}
public sealed record GetAllOperationsQuery : IQuery<(IReadOnlyCollection<Operation> Operations, int TotalCount)>;