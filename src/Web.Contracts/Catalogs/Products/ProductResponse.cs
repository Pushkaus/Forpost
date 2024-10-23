namespace Forpost.Web.Contracts.Catalogs.Products;

public sealed class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Purchased  { get;set;}
    public bool CategoryId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}