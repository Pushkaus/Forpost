using Forpost.Domain.Catalogs.TechCards.Operations;

namespace Forpost.Application.Contracts.Catalogs.TechCards;

public sealed class CompositionTechCardModel
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public Guid ProductId { get; set; }
    public string? Description { get; set; }
    public IReadOnlyCollection<OperationSummary>? Operations { get; set; }
    public IReadOnlyCollection<ItemSummary>? Items { get; set; }
}

public sealed class OperationSummary
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public OperationType Type { get; set; }
}

public sealed class ItemSummary
{
    public Guid Id { get; set; }
    public Guid TechCardId { get; set; }

    public Guid ProductId { get; set; }
    
    public string ProductName { get; set; } = string.Empty;
    
    public int Quantity { get; set; }
}

