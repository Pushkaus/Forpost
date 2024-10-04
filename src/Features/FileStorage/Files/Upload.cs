using AutoMapper;
using Forpost.Domain.FileStorage;
using Mediator;
using Microsoft.Extensions.Configuration;
using File = Forpost.Domain.FileStorage.File;

namespace Forpost.Features.FileStorage.Files;

internal sealed class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, Guid>
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

    public async ValueTask<Guid> Handle(UploadFileCommand command, CancellationToken cancellationToken)
    {
        var uploadFilePath = _configuration.GetValue<string>("FileStorage:UploadFilePath") ??
                             throw new ArgumentException("Не указан FileStorage:UploadFilePath");

        // Путь к файлу - Files/ParentId/FileName
        var filePath = Path.Combine(command.ParentId.ToString(), command.FileName);
        var fullPath = Path.Combine(uploadFilePath, filePath);
        var directory = Path.GetDirectoryName(fullPath);

        try
        {
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory); // Создаем директорию, если она не существует
            }

            // Записываем файл
            await System.IO.File.WriteAllBytesAsync(fullPath, command.Content, cancellationToken);

            var fileEntity = _mapper.Map<File>(command);
            fileEntity.FilePath = fullPath;

            return await Task.FromResult(_domainRepository.Add(fileEntity));
        }
        catch (UnauthorizedAccessException ex)
        {
            // Обработка ошибки доступа
            throw new Exception("Ошибка доступа к файлу. Проверьте, есть ли разрешения на запись.", ex);
        }
        catch (Exception ex)
        {
            // Общая обработка ошибок
            throw new Exception("Произошла ошибка во время загрузки файла.", ex);
        }
    }
}

public record UploadFileCommand(string FileName, byte[] Content, string ContentType, Guid ParentId) : ICommand<Guid>;
