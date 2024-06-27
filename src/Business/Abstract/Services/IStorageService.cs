namespace Forpost.Business.Abstract.Services;

public interface IStorageService
{
    public Task<string> CreateStorageAsync(string storageName, Guid userId, Guid responsibleId, CancellationToken cancellationToken);
}