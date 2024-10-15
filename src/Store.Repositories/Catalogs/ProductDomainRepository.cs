using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class ProductDomainRepository : DomainRepository<Product>, IProductDomainRepository
{
    public ProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<Product?> GetByBarcodeAsync(string barcode, CancellationToken cancellationToken)
    {
        return await DbSet.Where(p => p.Barcode == barcode).FirstOrDefaultAsync(cancellationToken);
    }
}