namespace Forpost.Store.Entities;

public sealed class SubProduct
{
    // Идентификатор родительского продукта
    public Guid ParentId { get; set; }

    // Идентификатор дочернего продукта
    public Guid DaughterId { get; set; }
    
    public int Count { get; set; }

    // Навигационные свойства
    public Product ParentProduct { get; set; }
    public Product DaughterProduct { get; set; }
}
