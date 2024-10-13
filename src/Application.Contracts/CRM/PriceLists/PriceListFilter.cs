namespace Forpost.Application.Contracts.CRM.PriceLists;

public sealed class PriceListFilter
{
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
    public string? ProductName { get; set; } = string.Empty;
}