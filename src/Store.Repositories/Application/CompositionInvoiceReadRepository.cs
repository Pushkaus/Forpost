using Forpost.Application.Contracts.CRM.InvoiceManagement.CompositionInvoices;
using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CompositionInvoiceReadRepository : ICompositionInvoiceReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public CompositionInvoiceReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<CompletedProductModel>> GetRelevantProducts(Guid invoiceId, Guid productId,
        CancellationToken cancellationToken)
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
                    ProductDevelopmentId = product.Id,
                    SerialNumber = combined.productDevelopment.SerialNumber
                })
            .Where(entity => entity.ProductDevelopmentId == productId)
            .ToListAsync(cancellationToken);

        return completedProducts;
    }

    public async Task<IReadOnlyCollection<CompositionInvoiceModel>> GetCompositionInvoice(Guid invoiceId,
        CancellationToken cancellationToken)
    {
        return await _dbContext.CompositionInvoices.Where(invoice => invoice.InvoiceId == invoiceId)
            .Join(_dbContext.Products,
                composition => composition.ProductId,
                product => product.Id,
                (composition, product) => new { composition, product })
            .Join(_dbContext.CompletedProducts,
                combined => combined.composition.CompletedProductId,
                completedProduct => completedProduct.Id,
                (combined, completedProduct) => new { combined, completedProduct })
            .Join(_dbContext.ProductDevelopments,
                combined => combined.completedProduct.ProductDevelopmentId,
                productDevelopment => productDevelopment.Id,
                (combined, productDevelopment) => new { combined, productDevelopment })
            .Join(_dbContext.Invoices,
                combined => combined.combined.combined.composition.InvoiceId,
                invoice => invoice.Id,
                (combined, invoice) => new CompositionInvoiceModel
                {
                    Id = combined.combined.combined.composition.Id,
                    InvoiceId = combined.combined.combined.composition.InvoiceId,
                    Number = invoice.Number,
                    ProductId = combined.combined.combined.composition.ProductId,
                    ProductName = combined.combined.combined.product.Name,
                    CompletedProductId = combined.combined.completedProduct.Id,
                    ProductDevelopmentId = combined.combined.completedProduct.ProductDevelopmentId,
                    SerialNumber = combined.productDevelopment.SerialNumber
                })
            .ToListAsync(cancellationToken);
    }
}