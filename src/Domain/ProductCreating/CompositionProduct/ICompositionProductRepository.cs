using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.CompositionProduct;

public interface ICompositionProductRepository: IDomainRepository<CompositionProduct>
{
    public Task<IReadOnlyCollection<CompositionProduct>> GetCompositionProductsAsync(Guid productId,
        CancellationToken cancellationToken);
}