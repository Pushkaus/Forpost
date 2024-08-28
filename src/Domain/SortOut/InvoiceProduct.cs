using Forpost.Common.EntityTemplates;

namespace Forpost.Domain.SortOut;

/// <summary>
/// Состав счета
/// </summary>
public sealed class InvoiceProduct : DomainEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}