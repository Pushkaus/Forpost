using Forpost.Store.Entities;
using Forpost.Web.Contracts.Models.Storages;

namespace Forpost.Business.Abstract.Services;

public interface IStorageService
{
    public Task Add(StorageCreateModel model);
    public Task<IReadOnlyList<Storage?>> GetAll();
}