using Forpost.Common.DataAccess;
using Forpost.Domain.Catalogs.Category;

namespace Forpost.Application.Contracts.Catalogs.Categories;

public interface ICategoryReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<CategoryWithChildrenModel>> GetCategoriesAsync(CategoryFilter filter,
        CancellationToken cancellationToken);
}