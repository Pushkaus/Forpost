namespace Forpost.Application.Contracts.CompositionCompletedProducts;

public sealed class CompositionCompletedProductWithSummary
{
    public Guid CompletedItemId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    public string CompletedItemName { get; set; }
    public string SerialNumber { get; set; }
}