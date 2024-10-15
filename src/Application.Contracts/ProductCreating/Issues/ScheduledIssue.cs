namespace Forpost.Application.Contracts.ProductCreating.Issues;

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
    /// Флаг, указывающий нужно ли указывать состав продукта после завершения задачи
    /// </summary>
    public bool ProductCompositionSettingFlag { get; set; } = default;
}