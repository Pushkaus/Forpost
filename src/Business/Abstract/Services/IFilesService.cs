using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IFilesService: IBusinessService
{
    public Task UploadFile(Guid parentId, string fileName, string contentType, byte[] content);
    public Task<(byte[] fileContent, string ContentType, string FileName)> DownloadFile(Guid id);
    public Task<IReadOnlyList<FileEntity?>> GetAllFiles(Guid parentId);
    public Task DeleteFile(Guid id);
}