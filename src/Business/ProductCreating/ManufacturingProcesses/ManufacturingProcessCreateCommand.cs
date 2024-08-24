namespace Forpost.Business.ProductCreating.ManufacturingProcesses;

public sealed class ManufacturingProcessCreateCommand
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
}