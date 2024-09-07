using Forpost.Domain.Catalogs.Products;
using Forpost.Domain.ProductCreating.ProductDevelopment;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetAllDevelopmentProductsQueryHandler: 
    IQueryHandler<GetAllDevelopmentProductsQuery, IReadOnlyCollection<ProductDevelopment>>
{
    private readonly IProductDevelopmentDomainRepository _productDevelopmentDomainRepository;

    public GetAllDevelopmentProductsQueryHandler(IProductDevelopmentDomainRepository productDevelopmentDomainRepository)
    {
        _productDevelopmentDomainRepository = productDevelopmentDomainRepository;
    }

    public async ValueTask<IReadOnlyCollection<ProductDevelopment>> Handle(GetAllDevelopmentProductsQuery query, CancellationToken cancellationToken)
    {
        return await _productDevelopmentDomainRepository.GetAllAsync(cancellationToken);
    }
}
public record GetAllDevelopmentProductsQuery(): IQuery<IReadOnlyCollection<ProductDevelopment>>;