using Forpost.Business.EventHanding;

namespace Forpost.Business.Events.Products;

/// <summary>
/// Продукт добавлен к заказу
/// </summary>
public sealed class ProductInInvoiceAdded2 : IDomainEvent
{
    /// <summary>
    /// Ид счётв
    /// </summary>
    public Guid InvoiceId { get; set; }
    
    /// <summary>
    /// Ид продукта
    /// </summary>
    public Guid ProductId { get; set; }
    
    /// <summary>
    /// Количество к списанию
    /// </summary>
    public int Quantity { get; set; }
}