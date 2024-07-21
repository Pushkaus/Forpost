using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class StorageProductRepository: Repository<StorageProduct>, IStorageProductRepository
{
    public StorageProductRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<StorageProduct>> GetAllById(Guid id)
    {
        return await DbSet.Include(sp => sp.Product)
            .Include(sp => sp.Storage)
            .Where(entity => entity.StorageId == id).ToListAsync();
    }

    public async Task<StorageProduct?> GetById(Guid id)
    {
        return await DbSet.Where(entity => entity.ProductId == id).FirstOrDefaultAsync();
            
    }
}