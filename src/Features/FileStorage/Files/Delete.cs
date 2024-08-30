using Forpost.Common;
using Forpost.Domain.FileStorage;
using MediatR;

namespace Forpost.Application.FileStorage.Files;

internal sealed class DeleteFileByIdCommandHandler : IRequestHandler<DeleteFileByIdCommand>
{
    private readonly IFileDomainRepository _domainRepository;

    public DeleteFileByIdCommandHandler(IFileDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task Handle(DeleteFileByIdCommand request, CancellationToken cancellationToken)
    {
        var fileId = request.Id;

        var file = await _domainRepository.GetByIdAsync(fileId, cancellationToken);
        file.EnsureFoundBy(x => x.Id, fileId);

        var fullPath = Path.Combine(file!.FilePath);
        _domainRepository.DeleteById(fileId);

        if (System.IO.File.Exists(fullPath)) System.IO.File.Delete(fullPath);
    }
}

public sealed record DeleteFileByIdCommand(Guid Id) : IRequest;