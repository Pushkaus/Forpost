using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Forpost.Business.Models.Files;
using Forpost.Common;

namespace Forpost.Business.Services;

internal sealed class FileService : IFileService
{
    private readonly IFilesRepository _filesRepository;
    private readonly IMapper _mapper;
    private readonly string? _uploadFilePath;

    public FileService(IFilesRepository filesRepository, IConfiguration configuration, IMapper mapper)
    {
        _filesRepository = filesRepository;
        _mapper = mapper;
        _uploadFilePath = configuration.GetValue<string>("FileStorage:UploadFilePath");
    }

    public async Task<Guid> UploadFileAsync(UploadFileModel model, CancellationToken cancellationToken)
    {
        // ParentId - это любой ID из БД, к которому нужно привязать файл.
        // Путь к файлу Files/ParentId/FileName
        var filePath = Path.Combine(model.ParentId.ToString(), $"{(model.FileName)}");
            
        var fullPath = Path.Combine(_uploadFilePath, filePath);
            
        var directory = Path.GetDirectoryName(fullPath);
            
        if (Directory.Exists(directory) is false)
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllBytesAsync(fullPath, model.Content);
        var fileEntity = _mapper.Map<FileEntity>(model);
        fileEntity.FilePath = fullPath;
            
        return await _filesRepository.AddAsync(fileEntity, cancellationToken);
    }

    public async Task<DownloadFileModel?> DownloadFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var file = await _filesRepository.GetByIdAsync(id, cancellationToken);
        file.EnsureFoundBy(x => x.Id, id);
            
        var fullPath = Path.Combine(file.FilePath);
        var fileContent = await File.ReadAllBytesAsync(fullPath);
            
        var downloadFile = _mapper.Map<DownloadFileModel>(file);
        downloadFile.FileContent = fileContent;
        return downloadFile;
    }

    public async Task DeleteFileAsync(Guid id, CancellationToken cancellationToken)
    {
        var file = await _filesRepository.GetByIdAsync(id, cancellationToken);
        file.EnsureFoundBy(x => x.Id, id);

        var fullPath = Path.Combine(file.FilePath);
        await _filesRepository.DeleteByIdAsync(id, cancellationToken);

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }

    public async Task<IReadOnlyList<FileEntity>> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken)
    {
        return await _filesRepository.GetAllByParentIdAsync(parentId, cancellationToken);
    }
}