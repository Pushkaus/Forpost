using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository: ISubRepository<StorageProduct>
{
    public Task<IReadOnlyList<StorageProduct>> GetAllById(Guid id);

}