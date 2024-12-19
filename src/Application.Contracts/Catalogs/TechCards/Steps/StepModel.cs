namespace Forpost.Application.Contracts.Catalogs.TechCards.Steps;

public sealed class StepModel
{
    public Guid Id { get; set; }
    
    public string OperationName { get; set; } = string.Empty;
    /// <summary>
    /// Ссылка на операцию (пайка/мойка/сборка и тд)
    /// </summary>
    public Guid OperationId { get; set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Длительность
    /// </summary>
    public TimeSpan Duration { get; set; }
}