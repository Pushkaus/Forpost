using Forpost.Common;
using Forpost.Domain.Catalogs.Operations;
using MediatR;

namespace Forpost.Application.Catalogs.Operations;

internal sealed class GetOperationByIdQueryHandler : IRequestHandler<GetOperationByIdQuery, Operation>
{
    private readonly IOperationRepository _repository;

    public GetOperationByIdQueryHandler(IOperationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Operation> Handle(GetOperationByIdQuery request, CancellationToken cancellationToken)
    {
        var operation = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return operation.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetOperationByIdQuery(Guid Id) : IRequest<Operation>;