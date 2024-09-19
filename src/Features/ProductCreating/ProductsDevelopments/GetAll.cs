using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetAllDevelopmentProductsQueryHandler : 
    IQueryHandler<GetAllDevelopmentProductsQuery, (IReadOnlyCollection<ProductDevelopmentModel> Developments, int TotalCount)>
{

    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public GetAllDevelopmentProductsQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<ProductDevelopmentModel> Developments, int TotalCount)> 
        Handle(GetAllDevelopmentProductsQuery query, CancellationToken cancellationToken)
    {
        var result = await _productDevelopmentReadRepository.GetAllAsync(cancellationToken, query.Skip, query.Limit);
        return (result.ProductDevelopments, result.TotalCount);
    }
}

// Запрос для получения всех продуктов разработки
public record GetAllDevelopmentProductsQuery(int Skip, int Limit) : IQuery<(IReadOnlyCollection<ProductDevelopmentModel> Developments, int TotalCount)>;