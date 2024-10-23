namespace Forpost.Application.Contracts.Catalogs.Categories;

public sealed class CategoryWithChildrenModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }

    public List<CategoryWithChildrenModel> Children { get; set; } =
        new List<CategoryWithChildrenModel>();
}