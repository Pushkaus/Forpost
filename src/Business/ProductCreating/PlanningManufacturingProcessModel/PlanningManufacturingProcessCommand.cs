namespace Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;

public sealed class PlanningManufacturingProcessCommand
{
    public Guid TechnologicalCardId { get; set; }
    /// <summary>
    ///     Номер партии
    /// </summary>
    public string BatchNumber { get; set; } = null!;

    /// <summary>
    ///     Целевое количество продукта в производственном процессе
    /// </summary>
    public int TargetQuantity { get; set; } 
    /// <summary>
    ///     Дата начала выполнения производственного процесса
    /// </summary>
    public DateTimeOffset StartTime { get; set; }

    public IReadOnlyCollection<StartingIssueCommand> Issues { get; set; } = Array.Empty<StartingIssueCommand>();
}