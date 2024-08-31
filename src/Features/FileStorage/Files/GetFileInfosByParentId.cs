using Forpost.Domain.FileStorage;
using Mediator;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Features.FileStorage.Files;

internal sealed class GetAllFileInfosByProductIdQueryHandler :
    IQueryHandler<GetAllFileInfosByProductIdQuery, IReadOnlyCollection<File>>
{
    private readonly IFileDomainRepository _domainRepository;

    public GetAllFileInfosByProductIdQueryHandler(IFileDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<File>> Handle(GetAllFileInfosByProductIdQuery request,
        CancellationToken cancellationToken) =>
        await _domainRepository.GetAllByParentIdAsync(request.ParentId, cancellationToken);
}

public sealed record GetAllFileInfosByProductIdQuery(Guid ParentId) : IQuery<IReadOnlyCollection<File>>;