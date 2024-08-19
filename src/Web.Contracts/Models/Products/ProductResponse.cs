namespace Forpost.Web.Contracts.Models.Products;

internal sealed class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? CategoryId { get; set; }
    public string? Version { get; set; }
    public decimal? Cost { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Guid? DeletedById { get; set; }
}