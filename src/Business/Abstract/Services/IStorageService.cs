using Forpost.Business.Models.Storages;
using Forpost.Store.Entities;

namespace Forpost.Business.Abstract.Services;

public interface IStorageService: IBusinessService
{
    public Task Add(StorageCreateModel model);
    public Task<IReadOnlyList<Storage?>> GetAll();
}