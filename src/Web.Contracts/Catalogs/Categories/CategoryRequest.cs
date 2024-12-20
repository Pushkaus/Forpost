namespace Forpost.Web.Contracts.Catalogs.Categories;

public sealed class CategoryRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; } 
}