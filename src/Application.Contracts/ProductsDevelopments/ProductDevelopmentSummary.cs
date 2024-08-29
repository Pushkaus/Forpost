namespace Forpost.Application.Contracts.ProductsDevelopments;

public sealed class ProductDevelopmentSummary
{
    public Guid ManufacturingProcessId { get; set; }
    public Guid ProductId { get; set; }
    public string BatchNumber { get; set; }
    public int TargetQuantity { get; set; }
}