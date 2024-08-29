using Forpost.Common;
using Forpost.Domain.Catalogs.Storages;
using MediatR;

namespace Forpost.Application.Catalogs.Storages;

internal sealed class GetStorageByIdQueryHandler : IRequestHandler<GetStorageByIdQuery, Storage>
{
    private readonly IStorageDomainRepository _domainRepository;

    public GetStorageByIdQueryHandler(IStorageDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<Storage> Handle(GetStorageByIdQuery request, CancellationToken cancellationToken)
    {
        var storage = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return storage.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetStorageByIdQuery(Guid Id) : IRequest<Storage>;