using Forpost.Application.Contracts.Catalogs.Categories;
using Forpost.Domain.Catalogs.Category;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class CategoryReadRepository : ICategoryReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public CategoryReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<CategoryWithChildrenModel>> GetCategoriesAsync(CategoryFilter filter,
        CancellationToken cancellationToken)
    {
        var categories = await _dbContext.Categories.AsNoTracking().ToListAsync(cancellationToken);

        if (!categories.Any())
        {
            return Array.Empty<CategoryWithChildrenModel>();
        }

        var uniqueCategories = categories.GroupBy(c => c.Id).Select(g => g.First()).ToList();

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            var nameFilter = filter.Name.Trim().ToLower();
            uniqueCategories = uniqueCategories.Where(c => c.Name != null && c.Name.ToLower().Contains(nameFilter))
                .ToList();
        }

        if (filter.ParentCategoryId.HasValue)
        {
            uniqueCategories = uniqueCategories.Where(c => c.ParentCategoryId == filter.ParentCategoryId.Value)
                .ToList();
        }

        var categoryDict = uniqueCategories.ToDictionary(c => c.Id, c => new CategoryWithChildrenModel
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ParentCategoryId = c.ParentCategoryId,
            Children = new List<CategoryWithChildrenModel>()
        });

        var rootCategories = new List<CategoryWithChildrenModel>();

        foreach (var category in categoryDict.Values)
        {
            if (category.ParentCategoryId == Guid.Empty)
            {
                rootCategories.Add(category);
            }
            else
            {
                var parentId = category.ParentCategoryId.Value;
                if (categoryDict.TryGetValue(parentId, out var parentCategory))
                {
                    parentCategory.Children.Add(category);
                }
            }
        }

        return rootCategories; 
    }
}