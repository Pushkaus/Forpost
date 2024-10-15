namespace Forpost.Application.Contracts.ProductCreating.Issues;

public class IssueFromManufacturingProcessModel
{
    public Guid Id { get; set; }
    /// <summary>
    /// Название операции
    /// </summary>
    public string OperationName { get; set; } = null!;
    /// <summary>
    /// Номер задачи в очереди
    /// </summary>
    public int IssueNumber { get; set; }
    /// <summary>
    /// Исполнитель задачи
    /// </summary>
    public Guid ExecutorId { get; set; }

    /// <summary>
    /// Ответственный над исполнителем
    /// </summary>
    public Guid ResponsibleId { get; set; }

    /// <summary>
    /// Комментарий по работе
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Текущее количество
    /// </summary>
    public int CurrentQuantity { get; set; }

    public IssueStatusModel Status { get; set; }
    
    /// <summary>
    /// Дата начала выполнения задачи
    /// </summary>
    public DateTimeOffset? StartTime { get; set; }

    /// <summary>
    /// Дата завершения выполнения задачи
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }
    public bool ProductCompositionFlag { get; set; }
}