using Forpost.Common;
using Forpost.Domain.Catalogs.Operations;
using MediatR;

namespace Forpost.Application.Catalogs.Operations;

internal sealed class GetOperationByIdQueryHandler : IRequestHandler<GetOperationByIdQuery, Operation>
{
    private readonly IOperationDomainRepository _domainRepository;

    public GetOperationByIdQueryHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<Operation> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
    {
        var operation = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return operation.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetOperationByIdQuery(Guid Id) : IRequest<Operation>;