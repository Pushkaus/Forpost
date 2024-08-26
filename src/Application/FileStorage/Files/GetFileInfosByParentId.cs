using Forpost.Domain.FileStorage;
using MediatR;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Application.FileStorage.Files;

internal sealed class GetAllFileInfosByProductIdQueryHandler :
    IRequestHandler<GetAllFileInfosByProductIdQuery, IReadOnlyCollection<File>>
{
    private readonly IFileRepository _repository;

    public GetAllFileInfosByProductIdQueryHandler(IFileRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<File>> Handle(GetAllFileInfosByProductIdQuery request,
        CancellationToken cancellationToken) =>
        await _repository.GetAllByParentIdAsync(request.ParentId, cancellationToken);
}

public sealed record GetAllFileInfosByProductIdQuery(Guid ParentId) : IRequest<IReadOnlyCollection<File>>;