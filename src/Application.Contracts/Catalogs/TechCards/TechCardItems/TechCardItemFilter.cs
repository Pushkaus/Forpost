namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;

public sealed class TechCardItemFilter
{
    public int Skip { get; set; } = 0;
    public int Limit { get; set; } = 10;
}