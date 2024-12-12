using Forpost.Application.Contracts.StorageManagement;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class GetAllStoragesQueryHandler :
    IQueryHandler<GetAllStoragesQuery, IReadOnlyCollection<StorageModel>>
{
    private readonly IStorageReadRepository _domainRepository;

    public GetAllStoragesQueryHandler(IStorageReadRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<StorageModel>> Handle(GetAllStoragesQuery request,
        CancellationToken cancellationToken)
    {
        var storages = await _domainRepository.GetAllStorage(cancellationToken);
        return storages;
    }
}
public sealed record GetAllStoragesQuery : IQuery<IReadOnlyCollection<StorageModel>>;