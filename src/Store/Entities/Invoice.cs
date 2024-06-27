using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class Invoice: IAuditableEntity
{
    
    public Invoice(string number, string contragent, string description, Guid createdById, Guid updatedById)
    {
        Number = number;
        Contragent = contragent;
        Description = description;
        CreatedAt = DateTimeOffset.UtcNow;
        CreatedById = createdById;
        UpdatedAt = DateTimeOffset.UtcNow;
        UpdatedById = updatedById;
    }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    
}