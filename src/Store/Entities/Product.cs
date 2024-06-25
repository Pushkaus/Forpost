using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class Product : IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Version { get; set; }
    public decimal Cost { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    
    public Employee CreatedBy { get; set; }
    public Employee UpdatedBy { get; set; }
    public Employee? DeletedBy { get; set; }
    public ICollection<ProductWork> ProductWorks { get; set; }
    public ICollection<StorageProduct> StorageProducts { get; set; }
    
    // Навигационные свойства
    public ICollection<SubProduct> ParentSubProducts { get; set; }
    public ICollection<SubProduct> DaughterSubProducts { get; set; }
}
