namespace Forpost.Store.Entities;

public sealed class ProductCategory
{
    public Guid Id { get; set; }
    public Guid RootId { get; set; }
    public Guid ParentId { get; set; }
    public string Name { get; set; }
    public Product Product { get; set; } = null!;
    
    public ProductCategory RootCategory { get; set; }
    public ProductCategory ParentCategory { get; set; }
    public ICollection<ProductCategory> ChildCategories { get; set; }
    public ICollection<ProductCategory> DescendantCategories { get; set; }
}