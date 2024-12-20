using Forpost.Domain.Catalogs.TechCards.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.TechCards.Operations;

internal sealed class GetAllOperationsQueryHandler :
    IQueryHandler<GetAllOperationsQuery, IReadOnlyCollection<Operation>>
{
    private readonly IOperationDomainRepository _domainRepository;

    public GetAllOperationsQueryHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Operation>> Handle(GetAllOperationsQuery request,
        CancellationToken cancellationToken)
    {
        var operations = await _domainRepository.GetAllAsync(cancellationToken);
        return operations;
    }
}
public sealed record GetAllOperationsQuery: IQuery<IReadOnlyCollection<Operation>>;