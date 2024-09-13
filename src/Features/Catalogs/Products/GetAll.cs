using Forpost.Domain.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class GetAllProductsQueryHandler :
    IQueryHandler<GetAllProductsQuery, (IReadOnlyCollection<Product> Products, int TotalCount)>
{
    private readonly IProductDomainRepository _domainRepository;

    public GetAllProductsQueryHandler(IProductDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<(IReadOnlyCollection<Product> Products, int TotalCount)> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken, request.Skip, request.Limit);
}

public sealed record GetAllProductsQuery(int Skip, int Limit) : IQuery<(IReadOnlyCollection<Product> Products, int TotalCount)>;