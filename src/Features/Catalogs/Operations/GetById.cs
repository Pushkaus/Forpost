using Forpost.Common;
using Forpost.Domain.Catalogs.Operations;
using Mediator;

namespace Forpost.Features.Catalogs.Operations;

internal sealed class GetOperationByIdQueryHandler : IQueryHandler<GetOperationByIdQuery, Operation>
{
    private readonly IOperationDomainRepository _domainRepository;

    public GetOperationByIdQueryHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Operation> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
    {
        var operation = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return operation.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetOperationByIdQuery(Guid Id) : IQuery<Operation>;