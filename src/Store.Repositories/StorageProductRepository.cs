using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.StorageProduct;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class StorageProductRepository: Repository<StorageProduct>, IStorageProductRepository
{
    public StorageProductRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<ProductsOnStorage>> GetAllByStorageId(Guid id)
    {
        var result = await DbSet
            .Join(
                _db.Products,
                entity => entity.ProductId,
                product => product.Id,
                (entity, product) => new { entity, product }
            )
            .Join(
                _db.Storages,
                combined => combined.entity.StorageId,
                storage => storage.Id,
                (combined, storage) => new ProductsOnStorage
                {
                    ProductId = combined.entity.ProductId,
                    ProductName = combined.product.Name,
                    UnitOfMeasure = combined.entity.UnitOfMeasure,
                    Quantity = combined.entity.Quantity,
                    StorageId = combined.entity.StorageId,
                    StorageName = storage.Name 
                }
            )
            .ToListAsync();

        return result;
    }

    public async Task<StorageProduct?> GetById(Guid id)
    {
        return await DbSet.Where(entity => entity.ProductId == id).FirstOrDefaultAsync();
            
    }
}