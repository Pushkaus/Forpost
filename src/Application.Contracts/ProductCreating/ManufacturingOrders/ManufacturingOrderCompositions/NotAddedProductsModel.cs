namespace Forpost.Application.Contracts.ProductCreating.ManufacturingOrders.ManufacturingOrderCompositions;

public sealed class NotAddedProductsModel
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
}