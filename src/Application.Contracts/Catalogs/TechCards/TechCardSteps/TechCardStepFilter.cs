namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardSteps;

public sealed class TechCardStepFilter
{
    public int Skip { get; set; } = 10;
    public int Limit { get; set; } = 10;
}