namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardOperations;

public sealed class TechCardOperationFilter
{
    public int Skip { get; set; } = 10;
    public int Limit { get; set; } = 10;
}