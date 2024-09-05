using Forpost.Application.Contracts.InvoiceProducts;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories.Models.InvoiceProduct;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class InvoiceProductReadRepository: IInvoiceProductReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public InvoiceProductReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<InvoiceWithProducts>>
        GetProductsByInvoiceIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await _dbContext.InvoiceProducts.Where(entity => entity.InvoiceId == id)
            .Join(
                _dbContext.Products,
                entity => entity.ProductId,
                product => product.Id,
                (entity, product) => new
                {
                    Entity = entity,
                    Product = product
                }
            )
            .Join(
                _dbContext.Invoices,
                combined => combined.Entity.InvoiceId,
                invoice => invoice.Id,
                (combined, invoice) => new InvoiceWithProducts
                {
                    ProductId = combined.Entity.Id,
                    InvoiceId = combined.Entity.InvoiceId,
                    Name = combined.Product.Name,
                    Quantity = combined.Entity.Quantity
                }
            )
            .ToListAsync(cancellationToken);
        return result;
    }
}