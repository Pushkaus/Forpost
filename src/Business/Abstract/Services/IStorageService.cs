using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IStorageService : IBusinessService
{
    public Task AddAsync(StorageCreateModel model, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Storage?>> GetAllAsync(CancellationToken cancellationToken);
}