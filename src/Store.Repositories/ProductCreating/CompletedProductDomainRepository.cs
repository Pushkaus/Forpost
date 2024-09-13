using AutoMapper;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class CompletedProductDomainRepository : DomainRepository<CompletedProduct>, ICompletedProductDomainRepository
{
    public CompletedProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}