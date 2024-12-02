namespace Forpost.Application.Contracts.ProductCreating.ManufacturingOrders;

public sealed class ManufacturingOrderFilter
{
    public string? Number { get; set; }
    public int? Priority { get; set; }
    public int? ManufacturingOrderStatusValue { get; set; }
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}