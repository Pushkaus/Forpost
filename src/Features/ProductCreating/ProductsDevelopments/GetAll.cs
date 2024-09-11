using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetAllDevelopmentProductsQueryHandler : 
    IQueryHandler<GetAllDevelopmentProductsQuery, (IReadOnlyCollection<ProductDevelopment> Developments, int TotalCount)>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;

    public GetAllDevelopmentProductsQueryHandler(IProductDevelopmentDomainRepository productDevelopmentDomainRepository)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<ProductDevelopment> Developments, int TotalCount)> Handle(GetAllDevelopmentProductsQuery query, CancellationToken cancellationToken)
    {
        var developments = await _productDevelopmentDomainRepository.GetAllAsync(cancellationToken);
        return developments;
    }
}

// Запрос для получения всех продуктов разработки
public record GetAllDevelopmentProductsQuery(int Skip, int Limit) : IQuery<(IReadOnlyCollection<ProductDevelopment> Developments, int TotalCount)>;