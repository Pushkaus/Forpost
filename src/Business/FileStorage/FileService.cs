using AutoMapper;
using Forpost.Common;
using Forpost.EventBus;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.FileStorage;

internal sealed class FileService : BusinessService, IFileService
{
    public FileService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        IDomainEventBus domainEventBus,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, domainEventBus, timeProvider)
    {
    }

    public async Task<Guid> UploadFileAsync(UploadFileCommand model, CancellationToken cancellationToken)
    {
        // ParentId - это любой ID из БД, к которому нужно привязать файл.
        // Путь к файлу Files/ParentId/FileName
        var filePath = Path.Combine(model.ParentId.ToString(), $"{model.FileName}");

        var uploadFilePath = Configuration.GetValue<string>("FileStorage:UploadFilePath") ??
                             throw new ArgumentException("Не указан FileStorage:UploadFilePath");
        var fullPath = Path.Combine(uploadFilePath, filePath);

        var directory = Path.GetDirectoryName(fullPath);

        if (Directory.Exists(directory) is false) Directory.CreateDirectory(fullPath);

        await File.WriteAllBytesAsync(fullPath, model.Content, cancellationToken);
        var fileEntity = Mapper.Map<FileEntity>(model);
        fileEntity.FilePath = fullPath;

        DbUnitOfWork.FilesRepository.Add(fileEntity);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);

        //TODO:Потом получишь из БД айдишник
        return Guid.Empty;
    }

    public async Task<DownloadFileCommand?> DownloadFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var file = await DbUnitOfWork.FilesRepository.GetByIdAsync(id, cancellationToken);
        file.EnsureFoundBy(x => x.Id, id);

        var fullPath = Path.Combine(file!.FilePath);
        var fileContent = await File.ReadAllBytesAsync(fullPath, cancellationToken);

        var downloadFile = Mapper.Map<DownloadFileCommand>(file);
        downloadFile.FileContent = fileContent;
        return downloadFile;
    }

    public async Task DeleteFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var file = await DbUnitOfWork.FilesRepository.GetByIdAsync(id, cancellationToken);
        file.EnsureFoundBy(x => x.Id, id);

        var fullPath = Path.Combine(file!.FilePath);
        DbUnitOfWork.FilesRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);

        if (File.Exists(fullPath)) File.Delete(fullPath);
    }

    public async Task<IReadOnlyList<FileEntity>> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken)
    {
        return await DbUnitOfWork.FilesRepository.GetAllByParentIdAsync(parentId, cancellationToken);
    }
}