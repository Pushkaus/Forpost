using Forpost.Store.Enums;

namespace Forpost.Business.Models.CompletedProduct;

public sealed class CompletedProductCreateModel
{
    public Guid ProductId { get; set; }
    public Guid ManufacturingProcessId { get; set; }

    /// <summary>
    ///     Серийный номер продукта
    /// </summary>
    public string SerialNumber { get; set; } = null!;

    /// <summary>
    ///     Вариант настройки
    /// </summary>
    public SettingOption? SettingOption { get; set; }

    /// <summary>
    ///     Номер счета, в который уйдет продукт
    /// </summary>
    public Guid? InvoiceId { get; set; }

    public Guid Id { get; set; }
}