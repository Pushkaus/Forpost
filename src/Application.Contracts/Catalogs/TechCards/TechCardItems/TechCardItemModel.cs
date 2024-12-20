namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardItems;

public sealed class TechCardItemModel
{
    public Guid Id { get; set; }
    public Guid TechCardId { get; set; }

    /// <summary>
    /// Ссылка на продукт, из которого состоит целевой продукт в тех.карте
    /// </summary>
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    /// <summary>
    /// Необходимое количество, для создания единицы целевого продукта
    /// </summary>
    public int Quantity { get; set; }
}