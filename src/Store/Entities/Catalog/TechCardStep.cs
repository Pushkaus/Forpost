using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;
/// <summary>
/// Сущность, связывающая этапы и тех.карту
/// </summary>
public sealed class TechCardStep: IEntity
{
    public Guid Id { get; set; }
    public Guid TechnologicalCardId { get; set; }
    public Guid StepId { get; set; }
    /// <summary>
    /// Номер в очереди
    /// </summary>
    public int Number { get; set; }
}