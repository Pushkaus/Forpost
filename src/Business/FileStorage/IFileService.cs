using Forpost.Store.Entities;

namespace Forpost.Business.FileStorage;

public interface IFileService : IBusinessService
{
    public Task<Guid> UploadFileAsync(UploadFileCommand model, CancellationToken cancellationToken);
    public Task<DownloadFileCommand?> DownloadFileAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<FileEntity>> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken);
    public Task DeleteFileAsync(Guid id, CancellationToken cancellationToken);
}