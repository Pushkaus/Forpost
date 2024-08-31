using Forpost.Domain.Catalogs.Storages;
using Mediator;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class GetAllStoragesQueryHandler :
    IQueryHandler<GetAllStoragesQuery, IReadOnlyCollection<Storage>>
{
    private readonly IStorageDomainRepository _domainRepository;

    public GetAllStoragesQueryHandler(IStorageDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Storage>> Handle(GetAllStoragesQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllStoragesQuery : IQuery<IReadOnlyCollection<Storage>>;