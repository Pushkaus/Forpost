namespace Forpost.Application.Contracts.Catalogs.TechCards;

public sealed class CompositionTechCardModel
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string? Description { get; set; }
    public IReadOnlyCollection<StepSummary>? Steps { get; set; }
    public IReadOnlyCollection<ItemSummary>? Items { get; set; }
}

public sealed class StepSummary
{
    public Guid Id { get; set; }
    public Guid TechCardId { get; set; }
    public string OperationName { get; set; }
    public string? Description { get; set; }
    public TimeSpan Duration { get; set; }
    public decimal Cost { get; set; }
    public UnitOfMeasure UnitOfMeasure { get; set; }
}

public sealed class ItemSummary
{
    public Guid Id { get; set; }
    public Guid TechCardId { get; set; }

    public Guid ProductId { get; set; }
    
    public string ProductName { get; set; }
    
    public int Quantity { get; set; }
}

