using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class Invoice: IAuditableEntity
{
    public Invoice()
    {
        
    }

    public Invoice(Guid id, string number, string contragent, string comment, DateTimeOffset createdAt, Guid createdById, DateTimeOffset updatedAt, Guid updatedById)
    {
        Id =  id;
        Number = number;
        Contragent = contragent;
        Comment = comment;
        CreatedAt = createdAt;
        CreatedById = createdById;
        UpdatedAt = updatedAt;
        UpdatedById = updatedById;
    }

    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Contragent { get; set; }
    public string? Comment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    
}