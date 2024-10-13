namespace Forpost.Application.Contracts.CRM.PriceLists;

public sealed class PriceListModel
{
    public Guid Id { get; set; }
    public Guid OperationId { get; set; }
    public string OperationName { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public string UpdatedByName { get; set; } = string.Empty;
}