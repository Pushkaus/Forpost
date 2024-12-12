using Forpost.Application.Contracts.Catalogs.Categories;
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
            uniqueCategories = uniqueCategories
                .Where(c => c.Name != null && c.Name.ToLower().Contains(nameFilter))
                .ToList();
        }

        var categoryDict = uniqueCategories.ToDictionary(c => c.Id, c => new CategoryWithChildrenModel
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ParentCategoryId = c.ParentCategoryId,
            Children = []
        });

        
        if (filter.ParentCategoryId.HasValue)
        {
            var result = new List<CategoryWithChildrenModel>();
            if (!categoryDict.TryGetValue(filter.ParentCategoryId.Value, out var parentCategory))
                return result;
            
            result.Add(parentCategory);
            
            AddChildren(parentCategory, categoryDict);
            return result;
        }
        var rootCategories = new List<CategoryWithChildrenModel>();

        foreach (var category in categoryDict.Values.Where(category => category.ParentCategoryId == null))
        {
            rootCategories.Add(category); 
            AddChildren(category, categoryDict);
        }

        return rootCategories;
    }

    private void AddChildren(CategoryWithChildrenModel parentCategory,
        Dictionary<Guid, CategoryWithChildrenModel> categoryDict)
    {
        foreach (var category in categoryDict.Values.Where(category => category.ParentCategoryId == parentCategory.Id))
        {
            parentCategory.Children.Add(category);
            AddChildren(category, categoryDict);
        }
    }
}