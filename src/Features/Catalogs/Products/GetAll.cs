using Forpost.Application.Contracts;
using Forpost.Application.Contracts.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class GetAllProductsQueryHandler :
    IQueryHandler<GetAllProductsQuery, EntityPagedResult<ProductModel>>
{
    private readonly IProductReadRepository _domainRepository;

    public GetAllProductsQueryHandler(IProductReadRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<EntityPagedResult<ProductModel>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(request.Filter, cancellationToken);
}

public sealed record GetAllProductsQuery(
    ProductFilter Filter) : IQuery<EntityPagedResult<ProductModel>>;