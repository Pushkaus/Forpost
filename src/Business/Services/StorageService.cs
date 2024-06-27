using Forpost.Business.Abstract.Services;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

public class StorageService: IStorageService
{
    private readonly IStorageRepository _storageRepository;

    public StorageService(IStorageRepository storageRepository)
    {
        _storageRepository = storageRepository;
    }
    public async Task<string> CreateStorageAsync(string storageName, Guid userId, Guid responsibleId, CancellationToken cancellationToken)
    {
        var result = await _storageRepository.CreateStorageAsync( storageName,  userId,  responsibleId,  cancellationToken);
        return result;
    }
}