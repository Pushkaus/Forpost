using Forpost.Common;
using Forpost.Domain.Catalogs.Products;
using MediatR;

namespace Forpost.Features.Catalogs.Products;

internal sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductDomainRepository _domainRepository;

    public GetProductByIdQueryHandler(IProductDomainRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
        return product.EnsureFoundBy(entity => entity.Id, request.Id);
    }
}

public sealed record GetProductByIdQuery(Guid Id) : IRequest<Product>;