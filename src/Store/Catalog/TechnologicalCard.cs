using Forpost.Common.EntityAnnotations;
namespace Forpost.Store.Entities;

/// <summary>
/// Технологическая карта
/// </summary>
public sealed class TechnologicalCard: IEntity
{
    public Guid Id { get; set; }
    /// <summary>
    /// Номер тех.карты
    /// </summary>
    public string Number { get; set; }
    
    public string? Description { get; set; }
    /// <summary>
    /// Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// Состав тех.карты
    /// </summary>
    public Guid CompositionTechonogicalCardId { get; set; }
}