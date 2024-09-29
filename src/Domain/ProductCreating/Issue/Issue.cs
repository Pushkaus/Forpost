using Forpost.Domain.Primitives.EntityAnnotations;
using Forpost.Domain.Primitives.EntityTemplates;
using Forpost.Domain.ProductCreating.Issue.Events;

namespace Forpost.Domain.ProductCreating.Issue;
/// <summary>
/// Задача. Участвует в производственном процессе
/// </summary>
public sealed class Issue : AggregateRoot, ITimeFrameEntity
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
            IssueNumber = scheduledIssue.IssueNumber,
            ExecutorId = scheduledIssue.ResponsibleId,
            ResponsibleId = scheduledIssue.ResponsibleId,
            Description = scheduledIssue.Description,
            CurrentQuantity = 0,
            IssueStatus = IssueStatus.Pending,
            StartTime = null,
            EndTime = null,
            ProductCompositionSettingFlag = scheduledIssue.ProductCompositionSettingFlag
        };
        return issue;
    }

    public void Close()
    {
        IssueStatus = IssueStatus.Completed;
        EndTime = TimeProvider.System.GetUtcNow();
    }

    public void Complete()
    {
        CurrentQuantity += 1;
        if (ProductCompositionSettingFlag)
        {
            
        }
    }

    public void AssignExecutor(Guid executorId, Guid issueId)
    {
        ExecutorId = executorId;
        Raise(new ExecutorAssigned(executorId, issueId));
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
    /// Номер задачи в производственном процессе
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

    public IssueStatus IssueStatus { get; set; } = default!;
    
    /// <summary>
    /// Дата начала выполнения задачи
    /// </summary>
    public DateTimeOffset? StartTime { get; set; }

    /// <summary>
    /// Дата завершения выполнения задачи
    /// </summary>
    public DateTimeOffset? EndTime { get; set; }

    public bool ProductCompositionSettingFlag { get; set; } = default;
}