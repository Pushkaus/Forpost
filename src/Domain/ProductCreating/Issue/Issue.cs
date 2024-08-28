using Forpost.Common.EntityAnnotations;
using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.ProductCreating.Issue;
/// <summary>
/// Задача. Участвует в производственном процессе
/// </summary>
public sealed class Issue : DomainAuditableEntity, ITimeFrameEntity
{
    public void Launch()
    {
        StartTime = TimeProvider.System.GetUtcNow();
        IssueStatus = IssueStatus.InProgress;
    }
    public static Issue Schedule(Issue scheduledIssue)
    {
        var issue = new Issue
        {
            ManufacturingProcessId = scheduledIssue.ManufacturingProcessId,
            StepId = scheduledIssue.StepId,
            ExecutorId = default,
            ResponsibleId = scheduledIssue.ResponsibleId,
            Description = scheduledIssue.Description,
            CurrentQuantity = 0,
            IssueStatus = IssueStatus.Pending,
            StartTime = default,
            EndTime = null
        };
        return issue;
    }

    public void Complete()
    {
        IssueStatus = IssueStatus.Completed;
        EndTime = TimeProvider.System.GetUtcNow();
    }

    public void AssignExecutor(Guid executorId)
    {
        ExecutorId = executorId;
    }
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
    
    /// <summary>
    /// Дата начала выполнения задачи
    /// </summary>
    public DateTimeOffset StartTime { get; set; }

    /// <summary>
    /// Дата завершения выполнения задачи
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }
}