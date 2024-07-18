using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Invoice: IAuditableEntity, IEntity
{
    public Invoice()
    {
        
    }
    
    public Invoice(string number, Guid contragentId, string description, Guid createdById, Guid updatedById, int paymentPercentage, int daysShipment)
    {
        Number = number;
        ContragentId = contragentId;
        Description = description;
        CreatedAt = DateTimeOffset.UtcNow;
        CreatedById = createdById;
        UpdatedAt = DateTimeOffset.UtcNow;
        UpdatedById = updatedById;
        PaymentPercentage = paymentPercentage;
        DaysShipment = daysShipment;
    }
    
    public Guid Id { get; set; }
    public string Number { get; set; }
    public Guid ContragentId { get; set; }
    public string? Description { get; set; }
    public int PaymentPercentage { get; set; }
    public int DaysShipment { get; set; }
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