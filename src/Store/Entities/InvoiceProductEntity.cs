using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

/// <summary>
/// Состав счета
/// </summary>
public sealed class InvoiceProductEntity : IEntity
{
    public Guid InvoiceId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid Id { get; set; }
}