using Forpost.Domain.ProductCreating.ProductDevelopment;

namespace Forpost.Application.Contracts.ProductsDevelopments;

public sealed class InizializationProductDevelopment
{
    public Guid ManufacturingProcessId { get; set; }
    public Guid ProductId { get; set; }
    public string BatchNumber { get; set; }
    public int TargetQuantity { get; set; }
    public ProductStatus Status { get; set; }
}