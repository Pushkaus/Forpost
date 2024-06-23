using Forpost.Store.Contracts;

namespace Forpost.Store.Entities;

public sealed class Product: IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid ProductCategoryId { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
    
    public ProductCategory ProductCategory { get; set; }
    public ICollection<InvoiceProduct> InvoiceProducts { get; set; }
    public ICollection<ProductAssembly> ProductAssemblies { get; set; }  // Коллекция связей с 
    
}