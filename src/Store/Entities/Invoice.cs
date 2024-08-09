using Forpost.Common.EntityAnnotations;
using Forpost.Store.Enums;

namespace Forpost.Store.Entities;

public sealed class Invoice: IAuditableEntity, IEntity
{
    public Invoice()
    {
        
    }
    
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int PaymentPercentage { get; set; }
    public int DaysShipment { get; set; }
    public Status Status { get; set; }
    public DateTimeOffset? DateShipment { get; set; }
    public Guid? PaymentId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public Contragent Contragent { get; set; }
    public IReadOnlyCollection<InvoiceProduct> InvoiceProducts { get; set; }
    
}