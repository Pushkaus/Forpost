using Forpost.Domain.Catalogs.Operations;
using MediatR;

namespace Forpost.Application.Catalogs.Operations;

internal sealed class GetAllOperationsQueryHandler :
    IRequestHandler<GetAllOperationsQuery, IReadOnlyCollection<Operation>>
{
    private readonly IOperationRepository _repository;

    public GetAllOperationsQueryHandler(IOperationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Operation>> Handle(GetAllOperationsQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllOperationsQuery : IRequest<IReadOnlyCollection<Operation>>;