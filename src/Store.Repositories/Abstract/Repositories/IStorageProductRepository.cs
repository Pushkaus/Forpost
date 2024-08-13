using Forpost.Store.Entities;
using Forpost.Store.Repositories.Models.StorageProduct;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IStorageProductRepository: IRepository<StorageProduct>
{
    public Task<IReadOnlyList<ProductsOnStorage>> GetAllByStorageIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<StorageProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

}