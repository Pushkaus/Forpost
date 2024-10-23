using Forpost.Application.Contracts.Catalogs.Categories;
using Mediator;

namespace Forpost.Features.Catalogs.Categories;

internal sealed class
    GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, IReadOnlyCollection<CategoryWithChildrenModel>>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<CategoryWithChildrenModel>> Handle(GetAllCategoryQuery query,
        CancellationToken cancellationToken)
    {
        return await _categoryReadRepository.GetCategoriesAsync(query.Filter, cancellationToken);
    }
}

public record GetAllCategoryQuery(CategoryFilter Filter) : IQuery<IReadOnlyCollection<CategoryWithChildrenModel>>;