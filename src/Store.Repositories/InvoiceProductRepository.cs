using Forpost.Business.Models.InvoiceProducts;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed  class InvoiceProductRepository: Repository<InvoiceProduct>, IInvoiceProductRepository
{
    public InvoiceProductRepository(ForpostContextPostgres db) : base(db)
    {
    }

    public async Task<IReadOnlyList<InvoiceWithProducts>> GetProductsByInvoiceId(Guid id)
    {
        var result = await DbSet
            .Where(entity => entity.InvoiceId == id)
            .Join(
                _db.Products,
                entity => entity.ProductId,
                product => product.Id,
                (entity, product) => new
                {
                    Entity = entity,
                    Product = product
                }
            )
            .Join(
                _db.Invoices,
                combined => combined.Entity.InvoiceId, 
                invoice => invoice.Id, 
                (combined, invoice) => new InvoiceWithProducts
                {
                    ProductId = combined.Entity.Id,
                    Name= combined.Product.Name,
                    InvoiceId = combined.Entity.InvoiceId,
                    Quantity = combined.Entity.Quantity,
                }
            )
            .ToListAsync();
        return result;
    }

    public async Task DeleteByProductId(Guid id)
    {
        var product = await DbSet.FirstAsync(entity => entity.ProductId == id);
        DbSet.Entry(product).State = EntityState.Deleted;
        await _db.SaveChangesAsync();
    }
}