using Forpost.Domain.Catalogs.Steps;

namespace Forpost.Web.Contracts.Catalogs.TechCardSteps;

public sealed class CompositionTechCardResponse
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string? Description { get; set; }
    public IReadOnlyCollection<StepSummaryResponse>? Steps { get; set; } = Array.Empty<StepSummaryResponse>();
    public IReadOnlyCollection<ItemSummaryResponse>? Items { get; set; } = Array.Empty<ItemSummaryResponse>();
}

public sealed class StepSummaryResponse
{
    public Guid Id { get; set; }
    public Guid TechCardId { get; set; }
    public string OperationName { get; set; }
    public string? Description { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Cost { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
}

public sealed class ItemSummaryResponse
{
    public Guid Id { get; set; }
    public Guid TechCardId { get; set; }

    public Guid ProductId { get; set; }
    
    public string ProductName { get; set; }
    
    public int Quantity { get; set; }
}