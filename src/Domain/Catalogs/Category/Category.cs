using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Category;

public sealed class Category : DomainEntity
{
    public static Category Create(string name, Guid? parentCategoryId = null, string description = "", string version = "v1")
    {
        var category = new Category
        {
            Name = name,
            ParentCategoryId = parentCategoryId,
            Description = description
        };
        return category;
    }
    // Свойства категории
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание категории
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// ИД родительской категории (если есть)
    /// </summary>
    public Guid? ParentCategoryId { get; set; }
    
    // Навигационное свойство для родительской категории
    public Category? ParentCategory { get; set; }

    // Навигационное свойство для дочерних категорий
    public IReadOnlyCollection<Category> Children { get; set; } = new List<Category>();
}