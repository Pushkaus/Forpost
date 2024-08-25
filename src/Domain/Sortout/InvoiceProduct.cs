using Forpost.Common.EntityAnnotations;

namespace Forpost.Domain.Sortout;

/// <summary>
/// Состав счета
/// </summary>
public sealed class InvoiceProduct : IEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid Id { get; set; }
}