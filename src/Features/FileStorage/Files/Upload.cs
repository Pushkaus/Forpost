using AutoMapper;
using Forpost.Domain.FileStorage;
using MediatR;
using Microsoft.Extensions.Configuration;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Features.FileStorage.Files;

internal sealed class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, Guid>
{
    private readonly IFileDomainRepository _domainRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UploadFileCommandHandler(IFileDomainRepository domainRepository, IMapper mapper, IConfiguration configuration)
    {
        _domainRepository = domainRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<Guid> Handle(UploadFileCommand command, CancellationToken cancellationToken)
    {
        // ParentId - это любой ID из БД, к которому нужно привязать файл.
        // Путь к файлу Files/ParentId/FileName
        var filePath = Path.Combine(command.ParentId.ToString(), $"{command.FileName}");

        var uploadFilePath = _configuration.GetValue<string>("FileStorage:UploadFilePath") ??
                             throw new ArgumentException("Не указан FileStorage:UploadFilePath");
        var fullPath = Path.Combine(uploadFilePath, filePath);

        var directory = Path.GetDirectoryName(fullPath);

        if (Directory.Exists(directory) is false) Directory.CreateDirectory(fullPath);

        await System.IO.File.WriteAllBytesAsync(fullPath, command.Content, cancellationToken);
        var fileEntity = _mapper.Map<File>(command);
        fileEntity.FilePath = fullPath;

        return await Task.FromResult(_domainRepository.Add(fileEntity));
    }
}

public record UploadFileCommand(string FileName, byte[] Content, string ContentType, Guid ParentId) : IRequest<Guid>;