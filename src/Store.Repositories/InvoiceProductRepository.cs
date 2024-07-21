using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed  class InvoiceProductRepository: Repository<InvoiceProduct>, IInvoiceProductRepository
{
    private readonly ForpostContextPostgres _db;
    public InvoiceProductRepository(ForpostContextPostgres db) : base(db)
    {
        _db = db;
    }

    public async Task<IReadOnlyList<InvoiceProduct?>> GetProductsById(Guid id)
    {
        return await DbSet.Include(x => x.Product)
            .Include(x => x.Invoice).Where(entity => entity.InvoiceId == id).ToListAsync();
    }

    public async Task DeleteByProductId(Guid id)
    {
        var product = await DbSet.FirstAsync(entity => entity.ProductId == id);
        DbSet.Entry(product).State = EntityState.Deleted;
        await _db.SaveChangesAsync();
    }
}