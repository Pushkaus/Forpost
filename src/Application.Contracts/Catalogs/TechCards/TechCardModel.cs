namespace Forpost.Application.Contracts.Catalogs.TechCards;

public sealed class TechCardModel
{
    public Guid Id { get; set; }
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
    /// <summary>
    /// Имя продукта
    /// </summary>
    public string ProductName { get; set; } = null!;
}