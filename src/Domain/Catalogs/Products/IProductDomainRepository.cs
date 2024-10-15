using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.Products;

public interface IProductDomainRepository : IDomainRepository<Product>
{
    public Task<Product?> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken);
}