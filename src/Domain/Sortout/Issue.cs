using Forpost.Common.EntityAnnotations;

namespace Forpost.Domain.Sortout;

/// <summary>
/// Задача. Участвует в производственном процессе
/// </summary>
public class Issue : IEntity, IAuditableEntity, ITimeFrameEntity
{
    /// <summary>
    /// Ссылка на производственный процесс этой задачи
    /// </summary>
    public Guid ManufacturingProcessId { get; set; }

    /// <summary>
    /// Ссылка на этап из тех.карты
    /// </summary>
    public Guid StepId { get; set; }

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

    public IssueStatus IssueStatus { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Guid Id { get; set; }

    /// <summary>
    /// Дата начала выполнения задачи
    /// </summary>
    public DateTimeOffset StartTime { get; set; }

    /// <summary>
    /// Дата завершения выполнения задачи
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }
}