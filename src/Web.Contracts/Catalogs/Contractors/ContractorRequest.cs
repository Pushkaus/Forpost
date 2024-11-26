namespace Forpost.Web.Contracts.Catalogs.Contractors;

public sealed class ContractorRequest
{
    /// <summary>
    /// Имя контрагента
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// ИНН
    /// </summary>
    public string INN { get; set; }
    /// <summary>
    /// Страна контрагента
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// Город контрагента
    /// </summary>
    public string City { get; set; }
    /// <summary>
    /// Любая информация по контрагенту
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Уровень дисконта
    /// </summary>
    public decimal? DiscountLevel { get; set; }
    /// <summary>
    /// Информация по логистике
    /// </summary>
    public string? LogisticInfo { get; set; }
    /// <summary>
    /// Тип контрагента
    /// </summary>
    public int ContractorType { get; set; }
}