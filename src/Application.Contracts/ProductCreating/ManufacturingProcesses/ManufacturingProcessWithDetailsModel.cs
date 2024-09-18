namespace Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;

public sealed class ManufacturingProcessWithDetailsModel
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public Guid TechCardId { get; set; }
    public string TechCardNumber { get; set; } = null!;

    /// <summary>
    /// Номер партии
    /// </summary>
    public string BatchNumber { get; set; } = null!;

    /// <summary>
    /// Текущее количество продукта из производственного процесса
    /// </summary>
    public int CurrentQuantity { get; set; }

    /// <summary>
    /// Целевое количество продукта в производственном процессе
    /// </summary>
    public int TargetQuantity { get; set; }

    /// <summary>
    /// Дата начала выполнения производственного процесса
    /// </summary>
    public DateTimeOffset? StartTime { get; set; }

    /// <summary>
    /// Дата завершения выполнения производственного процесса
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }

    public ManufacturingProcessStatusModel Status { get; set; }
}