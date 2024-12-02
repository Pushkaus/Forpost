namespace Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

public sealed class ManufacturingOrderCompositionModel
{
    public Guid Id { get; set; }
    public Guid ManufacturingProcessOrderId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}