using AutoMapper;
using Forpost.Domain.Catalogs.Products;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories;

internal sealed class ProductDomainRepository : DomainRepository<Product>, IProductDomainRepository
{
    public ProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}