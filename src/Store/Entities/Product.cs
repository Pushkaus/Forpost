using System.ComponentModel.DataAnnotations.Schema;
using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public sealed class Product : IAuditableEntity, IEntity
{
    public Product() {}

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? CategoryId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    
    public IReadOnlyCollection<Component> ParentSubProducts { get; set; }
    public IReadOnlyCollection<Component> DaughterSubProducts { get; set; }
    public IReadOnlyCollection<ProductVersion> Version { get; set; }
    public IReadOnlyCollection<InvoiceProduct> InvoiceProducts { get; set; }
    public IReadOnlyCollection<StorageProduct> StorageProducts { get; set; }

    
}