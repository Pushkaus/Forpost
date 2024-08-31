using Forpost.Domain.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class GetAllProductsQueryHandler :
    IQueryHandler<GetAllProductsQuery, IReadOnlyCollection<Product>>
{
    private readonly IProductDomainRepository _domainRepository;

    public GetAllProductsQueryHandler(IProductDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<IReadOnlyCollection<Product>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllProductsQuery : IQuery<IReadOnlyCollection<Product>>;