using Forpost.Domain.FileStorage;
using MediatR;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Application.FileStorage.Files;

internal sealed class GetAllFileInfosByProductIdQueryHandler :
    IRequestHandler<GetAllFileInfosByProductIdQuery, IReadOnlyCollection<File>>
{
    private readonly IFileDomainRepository _domainRepository;

    public GetAllFileInfosByProductIdQueryHandler(IFileDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<File>> Handle(GetAllFileInfosByProductIdQuery request,
        CancellationToken cancellationToken) =>
        await _domainRepository.GetAllByParentIdAsync(request.ParentId, cancellationToken);
}

public sealed record GetAllFileInfosByProductIdQuery(Guid ParentId) : IRequest<IReadOnlyCollection<File>>;