using AutoMapper;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class ProductDevelopmentDomainRepository : DomainRepository<ProductDevelopment>, IProductDevelopmentDomainRepository
{
    public ProductDevelopmentDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}