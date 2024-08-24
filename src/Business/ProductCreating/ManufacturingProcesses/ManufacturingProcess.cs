using Forpost.Store.Enums;

namespace Forpost.Business.ProductCreating.ManufacturingProcesses;

public sealed class ManufacturingProcess
{
    public void Launch()
    {
        if (!IsProcessScheduled)
        {
            throw new Exception("Тут будет бизнес ошибка. Запускать можно только запланированный процесс");
        }

        StartTime = TimeProvider.System.GetUtcNow();
        Status = ManufacturingProcessStatus.InProgress;
    }
    
    public Guid TechnologicalCardId { get; private set; }

    /// <summary>
    /// Номер партии
    /// </summary>
    public string BatchNumber { get; private set; } = null!;

    /// <summary>
    /// Текущее количество продукта из производственного процесса
    /// </summary>
    public int CurrentQuantity { get; private set; }

    /// <summary>
    /// Целевое количество продукта в производственном процессе
    /// </summary>
    public int TargetQuantity { get; private set; }
    
    /// <summary>
    /// Дата начала выполнения производственного процесса
    /// </summary>
    public DateTimeOffset StartTime { get; private set; }

    /// <summary>
    /// Дата завершения выполнения производственного процесса
    /// </summary>
    public DateTimeOffset? EndTime { get; private set; }
    
    public ManufacturingProcessStatus Status { get; private set; }
    
    private bool IsProcessScheduled => Status == ManufacturingProcessStatus.InProgress;
}