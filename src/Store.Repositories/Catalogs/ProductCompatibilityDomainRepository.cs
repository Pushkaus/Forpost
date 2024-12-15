using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class ProductCompatibilityDomainRepository : DomainRepository<ProductCompatibility>,
    IProductCompabilityDomainRepository
{
    public ProductCompatibilityDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}