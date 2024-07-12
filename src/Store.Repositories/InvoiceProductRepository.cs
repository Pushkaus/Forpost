using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

public class InvoiceProductRepository: Repository<InvoiceProduct>, IInvoiceProductRepository
{
    public InvoiceProductRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<InvoiceProduct?>> GetProductsById(Guid id)
    {
        return await DbSet.Include(x => x.Product)
            .Include(x => x.Invoice).Where(entity => entity.InvoiceId == id).ToListAsync();
    }
}