using Forpost.Domain.Catalogs.Storages;
using MediatR;

namespace Forpost.Features.Catalogs.Storages;

internal sealed class GetAllStoragesQueryHandler :
    IRequestHandler<GetAllStoragesQuery, IReadOnlyCollection<Storage>>
{
    private readonly IStorageDomainRepository _domainRepository;

    public GetAllStoragesQueryHandler(IStorageDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<Storage>> Handle(GetAllStoragesQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllStoragesQuery : IRequest<IReadOnlyCollection<Storage>>;