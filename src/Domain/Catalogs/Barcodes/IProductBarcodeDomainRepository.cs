using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.Barcodes;

public interface IProductBarcodeDomainRepository : IDomainRepository<ProductBarcode>
{
    public Task<IReadOnlyCollection<ProductBarcode>>
        GetByProductId(Guid productId, CancellationToken cancellationToken);
    public Task<ProductBarcode?> GetByBarcode(string barcode, CancellationToken cancellationToken);
}