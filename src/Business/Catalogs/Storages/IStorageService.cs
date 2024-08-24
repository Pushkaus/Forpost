using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Catalogs.Storages;

public interface IStorageService : IBusinessService
{
    public Task AddAsync(StorageCreateCommand model, CancellationToken cancellationToken);
    public Task<IReadOnlyList<StorageEntity?>> GetAllAsync(CancellationToken cancellationToken);
}