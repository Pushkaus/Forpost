using Forpost.Application.Contracts.InvoiceManagment.CompositionInvoice;
using Forpost.Application.Contracts.InvoiceManagment.CompositionInvoices;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CompositionInvoiceReadRepository: ICompositionInvoiceReadRepository
{
    private readonly ForpostContextPostgres _dbContext;
    public CompositionInvoiceReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<CompletedProductModel>> GetRelevantProducts(Guid invoiceId, Guid productId, CancellationToken cancellationToken)
    {
        var productIds = await _dbContext.InvoiceProducts
            .Where(entity => entity.InvoiceId == invoiceId)
            .Select(entity => entity.ProductId)
            .ToListAsync(cancellationToken);

        var completedProducts = await _dbContext.CompletedProducts
            .Where(entity => productIds.Contains(entity.ProductId) && entity.Status == CompletedProductStatus.OnStorage)
            .Join(_dbContext.ProductDevelopments,
                completedProduct => completedProduct.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (completedProduct, productDevelopment) => new { completedProduct, productDevelopment })
            .Join(_dbContext.Products,
                combined => combined.completedProduct.ProductId,
                product => product.Id,
                (combined, product) => new CompletedProductModel
                {
                    Id = combined.completedProduct.Id,
                    Name = product.Name,
                    ProductId = product.Id,
                    SerialNumber = combined.productDevelopment.SerialNumber
                })
            .Where(entity => entity.ProductId == productId)
            .ToListAsync(cancellationToken);

        return completedProducts;

    }
}