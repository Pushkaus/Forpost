using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;
/// <summary>
/// Состав тех.карты
/// </summary>
public sealed class CompositionTechnologicalCard: IEntity
{
    public Guid Id { get; set; }
    public Guid TechnologicalCardId { get; set; }
    /// <summary>
    /// Ссылка на продукт, из которого состоит целевой продукт в тех.карте
    /// </summary>
    public Guid ProductId { get; set; }
    /// <summary>
    /// Необходимое количество, для создания единицы целевого продукта
    /// </summary>
    public int Quantity { get; set; }
}