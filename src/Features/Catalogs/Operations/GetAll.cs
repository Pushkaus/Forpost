using Forpost.Domain.Catalogs.Operations;
using MediatR;

namespace Forpost.Application.Catalogs.Operations;

internal sealed class GetAllOperationsQueryHandler :
    IRequestHandler<GetAllOperationsQuery, IReadOnlyCollection<Operation>>
{
    private readonly IOperationDomainRepository _domainRepository;

    public GetAllOperationsQueryHandler(IOperationDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<Operation>> Handle(GetAllOperationsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllOperationsQuery : IRequest<IReadOnlyCollection<Operation>>;