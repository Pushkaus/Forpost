using AutoMapper;
using Forpost.Domain.ProductCreating.CompositionCompletedProduct;
using Forpost.Store.Postgres;

namespace Forpost.Store.Repositories.CreatingProducts;

internal sealed class CompositionCompletedProductRepository: Repository<CompositionCompletedProduct>, ICompositionCompletedProduct
{
    public CompositionCompletedProductRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
}