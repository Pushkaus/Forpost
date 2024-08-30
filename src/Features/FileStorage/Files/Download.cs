using AutoMapper;
using Forpost.Common;
using Forpost.Domain.FileStorage;
using MediatR;

namespace Forpost.Features.FileStorage.Files;

internal sealed class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, FileModel>
{
    private readonly IFileDomainRepository _domainRepository;
    private readonly IMapper _mapper;

    public DownloadFileQueryHandler(IFileDomainRepository domainRepository, IMapper mapper)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
    }

    public async Task<FileModel> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
    {
        var file = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        file.EnsureFoundBy(entity => entity.Id, request.Id);

        var fullPath = Path.Combine(file!.FilePath);
        var fileContent = await System.IO.File.ReadAllBytesAsync(fullPath, cancellationToken);

        var downloadFile = _mapper.Map<FileModel>(file);
        downloadFile.FileContent = fileContent;
        return downloadFile;
    }
}

public record DownloadFileQuery(Guid Id) : IRequest<FileModel>;

public record FileModel()
{
    public byte[] FileContent { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public string FileName { get; set; } = default!;
}