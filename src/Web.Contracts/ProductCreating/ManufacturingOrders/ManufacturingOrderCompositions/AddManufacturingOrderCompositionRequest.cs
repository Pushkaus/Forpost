namespace Forpost.Web.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

public sealed class AddManufacturingOrderCompositionRequest
{
    public Guid ManufacturingOrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}