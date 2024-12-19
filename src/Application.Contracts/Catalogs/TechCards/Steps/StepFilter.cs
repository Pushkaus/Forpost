namespace Forpost.Application.Contracts.Catalogs.TechCards.Steps;

public sealed class StepFilter
{
    public Guid? OperationId { get; set; }
    public int Skip { get; set; } = 10;
    public int Limit { get; set; } = 10;
}