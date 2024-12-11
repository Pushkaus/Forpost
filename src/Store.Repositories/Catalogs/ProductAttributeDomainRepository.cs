using AutoMapper;
using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.Catalogs;

internal sealed class ProductAttributeDomainRepository : DomainRepository<ProductAttribute>,
    IProductAttributeDomainRepository
{
    public ProductAttributeDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}