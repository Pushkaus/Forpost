namespace Forpost.Application.Contracts.Issues;

public sealed class ScheduledIssue
{
    /// <summary>
    /// Ссылка на этап из тех.карты
    /// </summary>
    public Guid StepId { get; set; }

    /// <summary>
    /// Ответственный над исполнителем
    /// </summary>
    public Guid ResponsibleId { get; set; }

    /// <summary>
    /// Комментарий по работе
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Время старта задачи
    /// </summary>
    public DateTimeOffset StartTime { get; set; }
}