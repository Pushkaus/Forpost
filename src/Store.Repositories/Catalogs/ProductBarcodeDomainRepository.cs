using AutoMapper;
using Forpost.Domain.Catalogs.Barcodes;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class ProductBarcodeDomainRepository : DomainRepository<ProductBarcode>, IProductBarcodeDomainRepository
{
    public ProductBarcodeDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) :
        base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyCollection<ProductBarcode>> GetByProductId(Guid productId,
        CancellationToken cancellationToken) =>
        await DbSet.Where(p => p.ProductId == productId).ToListAsync(cancellationToken);

    public async Task<ProductBarcode?> GetByBarcode(string barcode, CancellationToken cancellationToken) =>
        await DbSet.FirstOrDefaultAsync(p => p.Barcode == barcode, cancellationToken);
}