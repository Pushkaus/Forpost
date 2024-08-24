using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities.ProductCreating;

public sealed class ProductDevelopmentEntity : IEntity
{
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    public ProductStatus Status { get; set; }
    public Guid Id { get; set; }
}