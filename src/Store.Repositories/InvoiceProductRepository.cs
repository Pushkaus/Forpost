using AutoMapper;
using Forpost.Store.Entities;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Store.Repositories.Models.InvoiceProduct;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class InvoiceProductRepository : Repository<InvoiceProductEntity>, IInvoiceProductRepository
{
    public InvoiceProductRepository(ForpostContextPostgres dbContext,  TimeProvider timeProvider, IMapper mapper) 
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<InvoiceWithProducts>>
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await DbSet
            .Where(entity => entity.InvoiceId == id)
            .Join(
                DbContext.Products,
                entity => entity.ProductId,
                product => product.Id,
                (entity, product) => new
                {
                    Entity = entity,
                    Product = product
                }
            )
            .Join(
                DbContext.Invoices,
                combined => combined.Entity.InvoiceId,
                invoice => invoice.Id,
                (combined, invoice) => new InvoiceWithProducts
                {
                    ProductId = combined.Entity.Id,
                    Name = combined.Product.Name,
                    InvoiceId = combined.Entity.InvoiceId,
                    Quantity = combined.Entity.Quantity
                }
            )
            .ToListAsync(cancellationToken);
        return result;
    }

    public async Task DeleteByProductIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await DbSet.FirstAsync(entity => entity.ProductId == id, cancellationToken);
        DbSet.Entry(product).State = EntityState.Deleted;
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}