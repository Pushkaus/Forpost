using Forpost.Common.EntityAnnotations;

namespace Forpost.Domain.ProductCreating.ProductDevelopment;

public sealed class ProductDevelopment : IEntity
{
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    public ProductStatus Status { get; set; }
    public Guid Id { get; set; }
}