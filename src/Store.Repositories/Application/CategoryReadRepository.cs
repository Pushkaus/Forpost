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
        // Загружаем категории из базы данных
        var categories = await _dbContext.Categories.AsNoTracking().ToListAsync(cancellationToken);

        // Если категории не загружены, возвращаем пустой список
        if (categories == null || categories.Count == 0)
        {
            // Включите логирование в избранной вами системе логирования если необходимо
            return Array.Empty<CategoryWithChildrenModel>();
        }

        // Преобразование сущностей в DTO
        var categoryDtos = categories.Select(c => new CategoryWithChildrenModel
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            ParentCategoryId = c.ParentCategoryId
        }).ToList();

        // Применение фильтров после загрузки
        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            var nameFilter = filter.Name.Trim().ToLower();
            categoryDtos = categoryDtos.Where(c => c.Name != null && c.Name.ToLower().Contains(nameFilter)).ToList();
        }

        if (filter.ParentCategoryId.HasValue)
        {
            categoryDtos = categoryDtos.Where(c => c.ParentCategoryId == filter.ParentCategoryId.Value).ToList();
        }

        // Построение словаря категорий по Id для доступа к ним по Id
        var categoryDict = categoryDtos.ToDictionary(c => c.Id);
        foreach (var category in categoryDtos)
        {
            // Проверка, что есть значение ParentCategoryId, чтобы идентифицировать дочерние категории
            if (!category.ParentCategoryId.HasValue) continue;
            if (categoryDict.TryGetValue(category.ParentCategoryId.Value, out var parentCategory))
            {
                parentCategory.Children.Add(category);
            }
        }
        return categoryDict.Values.ToList();
    }
}