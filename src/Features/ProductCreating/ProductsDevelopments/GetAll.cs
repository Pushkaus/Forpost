using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetAllDevelopmentProductsQueryHandler :
    IQueryHandler<GetAllDevelopmentProductsQuery, (IReadOnlyCollection<ProductDevelopmentModel> Developments, int
        TotalCount)>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public GetAllDevelopmentProductsQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<ProductDevelopmentModel> Developments, int TotalCount)>
        Handle(GetAllDevelopmentProductsQuery query, CancellationToken cancellationToken)
    {
        var result = await _productDevelopmentReadRepository.GetAllAsync(query.FilterExpression, query.FilterValues,
            query.Skip, query.Limit, cancellationToken);
        return (result.ProductDevelopments, result.TotalCount);
    }
}

// Запрос для получения всех продуктов разработки
public record GetAllDevelopmentProductsQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) : IQuery<(IReadOnlyCollection<ProductDevelopmentModel> Developments, int TotalCount)>;