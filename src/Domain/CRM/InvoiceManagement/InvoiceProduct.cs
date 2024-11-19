using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.CRM.InvoiceManagement;

/// <summary>
/// Состав счета
/// </summary>
public sealed class InvoiceProduct : DomainEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    
    /// <summary>
    /// Добавление продуктов в выставленный счет
    /// </summary>
    public static InvoiceProduct Add(Guid invoiceId, Guid productId, int quantity)
    {
        return new InvoiceProduct(invoiceId, productId, quantity);
    }
    
    private InvoiceProduct(Guid invoiceId, Guid productId, int quantity)
    {
        InvoiceId = invoiceId;
        ProductId = productId;
        Quantity = quantity;
    }
}