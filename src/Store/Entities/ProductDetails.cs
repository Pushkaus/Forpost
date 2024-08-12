using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public class ProductDetails: IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    /// <summary>
    /// Серийный номер продукта
    /// </summary>
    public int SerialNumber { get; set; }
    /// <summary>
    /// Вариант настройки
    /// </summary>
    public SettingOption SettingOption { get; set; }
    /// <summary>
    /// Номер счета, в который уйдет продукт
    /// </summary>
    public Guid InvoiceId { get; set; }
}