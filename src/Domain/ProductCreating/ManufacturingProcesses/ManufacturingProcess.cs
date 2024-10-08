using Forpost.Domain.Primitives.EntityAnnotations;
using Forpost.Domain.Primitives.EntityTemplates;
using Forpost.Domain.ProductCreating.ManufacturingProcesses.Events;

namespace Forpost.Domain.ProductCreating.ManufacturingProcesses;

public sealed class ManufacturingProcess : AggregateRoot,  ITimeFrameEntity
{
    public void Launch(Guid manufacturingProcessId)
    { 
        StartTime = TimeProvider.System.GetUtcNow();
        Status = ManufacturingProcessStatus.InProgress;
        Raise(new ManufacturingProcessLaunched(manufacturingProcessId));
    }

    public void Complete()
    {
        EndTime = TimeProvider.System.GetUtcNow();
        Status = ManufacturingProcessStatus.Completed;
    }

    public static ManufacturingProcess Schedule(
        Guid techCardId,
        string batchNumber,
        int targetQuantity,
        DateTimeOffset startTime)
    {
        var manufacturingProcess = new ManufacturingProcess
        {
            TechnologicalCardId = techCardId,
            BatchNumber = batchNumber,
            CurrentQuantity = 0,
            TargetQuantity = targetQuantity,
            StartTime = startTime,
            EndTime = null,
            Status = (ManufacturingProcessStatus.Pending)
        };
        return manufacturingProcess;
    }
    public Guid TechnologicalCardId { get; set; }

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

    public ManufacturingProcessStatus Status { get; set; }
}