using AutoMapper;
using Forpost.Domain.ProductCreating.CompositionProduct;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.ProductCreating;

internal sealed class CompositionProductDomainRepository: DomainRepository<CompositionProduct>, ICompositionProductRepository
{
    public CompositionProductDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider, IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }
    public async Task<IReadOnlyCollection<CompositionProduct>> GetCompositionProductsAsync(Guid productId, CancellationToken cancellationToken)
    {
        return await DbSet.Where(entity => entity.ProductId == productId)
            .ToListAsync(cancellationToken);
    }
}