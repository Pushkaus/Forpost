namespace Forpost.Business.ProductCreating.PlanningManufacturingProcessModel;
/// <summary>
/// Модель задачи, при запуске производственного процесса
/// </summary>
public sealed class StartingIssueCommand
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
    /// Ответственный над исполнителем
    /// </summary>
    public Guid ResponsibleId { get; set; }
    /// <summary>
    /// Комментарий по работе
    /// </summary>
    public string? Description { get; set; }
}