namespace Forpost.Web.Contracts.Models.CreatingProducts.PlanningManufacturingProcessModel;

public sealed class PlanningManufacturingProcess
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

    public IReadOnlyCollection<StartingIssue> Issues { get; set; } = Array.Empty<StartingIssue>();
}