using Forpost.Business.Models.Files;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IFileService: IBusinessService
{
    public Task UploadFile(UploadFileModel model);
    public Task<DownloadFileModel?> DownloadFile(Guid id);
    public Task<IReadOnlyList<FileEntity>> GetAllFiles(Guid parentId);
    public Task DeleteFile(Guid id);
}