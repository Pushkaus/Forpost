namespace Forpost.Web.Contracts.Catalogs.Contractors;

public sealed class ContractorRequest
{
    /// <summary>
    /// Имя контрагента
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// ИНН
    /// </summary>
    public string INN { get; }
    /// <summary>
    /// Страна контрагента
    /// </summary>
    public string Country { get; }
    /// <summary>
    /// Город контрагента
    /// </summary>
    public string City { get; }
    /// <summary>
    /// Любая информация по контрагенту
    /// </summary>
    public string? Description { get; }
    /// <summary>
    /// Уровень дисконта
    /// </summary>
    public decimal? DiscountLevel { get; }
    /// <summary>
    /// Информация по логистике
    /// </summary>
    public string? LogisticInfo { get; }
    /// <summary>
    /// Тип контрагента
    /// </summary>
    public int ContractorType { get; }

}