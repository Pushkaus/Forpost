using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;
/// <summary>
/// Серийный у отпускаемого продукта
/// </summary>
public sealed class SerialProduct: IEntity
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }
    /// <summary>
    /// Серийный номер продукта
    /// </summary>
    public string? SerialNumber { get; set; } 
    /// <summary>
    /// Вариант настройки
    /// </summary>
    public SettingOption? SettingOption { get; set; }
    /// <summary>
    /// Номер счета, в который уйдет продукт
    /// </summary>
    public Guid? InvoiceId { get; set; }
}