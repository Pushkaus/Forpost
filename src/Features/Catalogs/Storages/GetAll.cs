using Forpost.Domain.Catalogs.Storages;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class GetAllStoragesQueryHandler :
    IQueryHandler<GetAllStoragesQuery, (IReadOnlyCollection<Storage> Storages, int TotalCount)>
{
    private readonly IStorageDomainRepository _domainRepository;

    public GetAllStoragesQueryHandler(IStorageDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<Storage> Storages, int TotalCount)> Handle(GetAllStoragesQuery request,
        CancellationToken cancellationToken)
    {
        var storages = await _domainRepository.GetAllAsync(cancellationToken);
        return storages;
    }
}
public sealed record GetAllStoragesQuery : IQuery<(IReadOnlyCollection<Storage> Storages, int TotalCount)>;