namespace Forpost.Web.Contracts.Catalogs.TechCards;

public sealed class TechCardResponse
{
    /// <summary>
    /// Номер тех.карты
    /// </summary>
    public string Number { get; set; } = null!;

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Ссылка на продукт, относительно которого составляется тех.карта
    /// </summary>
    public Guid ProductId { get; set; }
    
    public string ProductName { get; set; } = null!;
}