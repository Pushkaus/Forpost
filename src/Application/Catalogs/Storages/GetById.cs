using Forpost.Common;
using Forpost.Domain.Catalogs.Storages;
using MediatR;

namespace Forpost.Application.Catalogs.Storages;

internal sealed class GetStorageByIdQueryHandler : IRequestHandler<GetStorageByIdQuery, Storage>
{
    private readonly IStorageRepository _repository;

    public GetStorageByIdQueryHandler(IStorageRepository repository)
    {
        _repository = repository;
    }

    public async Task<Storage> Handle(GetStorageByIdQuery request, CancellationToken cancellationToken)
    {
        var storage = await _repository.GetByIdAsync(request.Id, cancellationToken);
        return storage.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetStorageByIdQuery(Guid Id) : IRequest<Storage>;