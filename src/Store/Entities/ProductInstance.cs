using Forpost.Common.EntityAnnotations;

namespace Forpost.Store.Entities;

public class ProductInstance: IEntity
{
    public Guid Id { get; set; }
    public Product Product { get; set; } = null!; 
    public Guid ProductDetails { get; set; }
}