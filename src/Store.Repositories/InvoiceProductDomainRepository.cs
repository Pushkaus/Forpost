using AutoMapper;
using Forpost.Domain.SortOut;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories;

internal sealed class InvoiceProductDomainRepository : DomainRepository<InvoiceProduct>, IInvoiceProductDomainRepository
{
    public InvoiceProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyList<InvoiceProduct>>
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
                (combined, invoice) => new InvoiceProduct
                {
                    ProductId = combined.Entity.Id,
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