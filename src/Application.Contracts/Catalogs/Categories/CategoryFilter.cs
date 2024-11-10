namespace Forpost.Application.Contracts.Catalogs.Categories;

public sealed class CategoryFilter
{
    public string? Name { get; set; } = null;
    public Guid? ParentCategoryId { get; set; } = null;
}