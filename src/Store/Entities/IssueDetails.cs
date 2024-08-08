using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;
/// <summary>
/// Детали задачи
/// </summary>
public class IssueDetails: IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid IssueId { get; set; }
    /// <summary>
    /// Исполнитель задачи
    /// </summary>
    public Guid ExecutorId { get; set; }
    /// <summary>
    /// Ответственный над исполнителем
    /// </summary>
    public Guid ResponsibleId { get; set; }
    public Status Status { get; set; }
    /// <summary>
    /// Целевое количество
    /// </summary>
    public int TargetQuantity { get; set; }
    /// <summary>
    /// Текущее количество
    /// </summary>
    public int CurrentQuantity { get; set; }
    /// <summary>
    /// Единица измерения
    /// </summary>
    public UnitOfMeassure UnitOfMeassure { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Issue Issue { get; set; }
    public Employee Employee { get; set; }
}