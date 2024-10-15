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
}