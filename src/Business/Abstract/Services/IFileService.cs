using Forpost.Business.Models.Files;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IFileService : IBusinessService
{
    public Task<Guid> UploadFileAsync(UploadFileModel model, CancellationToken cancellationToken);
    public Task<DownloadFileModel?> DownloadFileAsync(Guid id, CancellationToken cancellationToken);
    public Task<IReadOnlyList<FileEntity>> GetAllFilesAsync(Guid parentId, CancellationToken cancellationToken);
    public Task DeleteFileAsync(Guid id, CancellationToken cancellationToken);
}