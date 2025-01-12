using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Crm.InvoiceManagement;

/// <summary>
/// Состав счета
/// </summary>
public sealed class InvoiceProduct : DomainEntity
{
    public Guid InvoiceId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    
    /// <summary>
    /// Добавление продуктов в выставленный счет
    /// </summary>
    public static InvoiceProduct Add(Guid invoiceId, Guid productId, int quantity)
    {
        return new InvoiceProduct(invoiceId, productId, quantity);
    }

    public void ChangeQuantity(int quantity)
    {
        Quantity = quantity;
    }
    
    private InvoiceProduct(Guid invoiceId, Guid productId, int quantity)
    {
        InvoiceId = invoiceId;
        ProductId = productId;
        Quantity = quantity;
    }
}