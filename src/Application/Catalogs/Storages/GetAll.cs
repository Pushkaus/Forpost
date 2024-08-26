using Forpost.Domain.Catalogs.Storages;
using MediatR;

namespace Forpost.Application.Catalogs.Storages;

internal sealed class GetAllStoragesQueryHandler :
    IRequestHandler<GetAllStoragesQuery, IReadOnlyCollection<Storage>>
{
    private readonly IStorageRepository _repository;

    public GetAllStoragesQueryHandler(IStorageRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Storage>> Handle(GetAllStoragesQuery request,
        CancellationToken cancellationToken) => await _repository.GetAllAsync(cancellationToken);
}

public sealed record GetAllStoragesQuery : IRequest<IReadOnlyCollection<Storage>>;