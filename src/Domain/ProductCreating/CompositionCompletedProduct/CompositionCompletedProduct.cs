using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.ProductCreating.CompositionCompletedProduct;

public sealed class CompositionCompletedProduct: DomainEntity
{
    public Guid CompletedProductId { get; set; }
    public Guid CompletedItemId { get; set; }
}