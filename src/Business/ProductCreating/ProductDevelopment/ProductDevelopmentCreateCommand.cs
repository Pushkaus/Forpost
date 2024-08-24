using Forpost.Store.Enums;

namespace Forpost.Business.ProductCreating.ProductDevelopment;

public sealed class ProductDevelopmentCreateCommand
{
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    public ProductStatus Status { get; set; }
    public Guid Id { get; set; }
}