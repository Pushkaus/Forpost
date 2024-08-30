using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Application.Catalogs.Products;

internal sealed class GetAllProductsQueryHandler :
    IRequestHandler<GetAllProductsQuery, IReadOnlyCollection<Product>>
{
    private readonly IProductDomainRepository _domainRepository;

    public GetAllProductsQueryHandler(IProductDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<IReadOnlyCollection<Product>> Handle(GetAllProductsQuery request,
        CancellationToken cancellationToken) => await _domainRepository.GetAllAsync(cancellationToken);
}

public sealed record GetAllProductsQuery : IRequest<IReadOnlyCollection<Product>>;