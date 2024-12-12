using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.Categories;

public interface ICategoryReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<CategoryWithChildrenModel>> GetCategoriesAsync(CategoryFilter filter,
        CancellationToken cancellationToken);
}