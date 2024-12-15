namespace Forpost.Web.Contracts.Crm.PriceLists;

public sealed class PriceListRequest
{
    public Guid OperationId { get; set; }
    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
}