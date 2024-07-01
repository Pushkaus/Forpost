namespace Forpost.Store.Entities;

public sealed class SubProduct
{
    // Идентификатор родительского продукта
    public Guid ParentId { get; set; }

    // Идентификатор дочернего продукта
    public Guid DaughterId { get; set; }
    // Единица измерения
    public string UnitOfMeasure { get; set; }
    // Количество
    public decimal Quantity { get; set; }

    // Навигационные свойства
    public Product ParentProduct { get; set; }
    public Product DaughterProduct { get; set; }
}
