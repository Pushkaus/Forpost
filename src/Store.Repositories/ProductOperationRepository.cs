using System.Collections;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class ProductOperationRepository : Repository<ProductOperation>, IProductOperationRepository
{
    public ProductOperationRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<ProductOperation>> GetAllByProductId(Guid id)
    {
        return await DbSet.Where(entity => entity.ProductId == id).ToListAsync();
    }
}
