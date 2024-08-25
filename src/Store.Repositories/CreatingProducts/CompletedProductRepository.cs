using AutoMapper;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class CompletedProductRepository : Repository<CompletedProduct>, ICompletedProductRepository
{
    public CompletedProductRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper)
        : base(dbContext, timeProvider, mapper)
    {
    }
}