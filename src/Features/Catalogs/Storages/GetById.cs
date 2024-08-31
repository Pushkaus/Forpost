using Forpost.Common;
using Forpost.Domain.Catalogs.Storages;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class GetStorageByIdQueryHandler : IQueryHandler<GetStorageByIdQuery, Storage>
{
    private readonly IStorageDomainRepository _domainRepository;

    public GetStorageByIdQueryHandler(IStorageDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<Storage> Handle(GetStorageByIdQuery request, CancellationToken cancellationToken)
    {
        var storage = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return storage.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetStorageByIdQuery(Guid Id) : IQuery<Storage>;