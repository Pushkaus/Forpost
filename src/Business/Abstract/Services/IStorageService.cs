using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;
using Forpost.Store.Entities.Catalog;

namespace Forpost.Business.Abstract.Services;

public interface IStorageService : IBusinessService
{
    public Task AddAsync(StorageCreateModel model, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Storage?>> GetAllAsync(CancellationToken cancellationToken);
}