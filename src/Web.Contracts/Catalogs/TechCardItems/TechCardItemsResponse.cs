namespace Forpost.Web.Contracts.Catalogs.TechCardItems;

public sealed class TechCardItemsResponse
{
    public Guid TechCardId { get; set; }

    /// <summary>
    ///     Ссылка на продукт, из которого состоит целевой продукт в тех.карте
    /// </summary>
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }

    /// <summary>
    ///     Необходимое количество, для создания единицы целевого продукта
    /// </summary>
    public int Quantity { get; set; }

    public Guid Id { get; set; }
}