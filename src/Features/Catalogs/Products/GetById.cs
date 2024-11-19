using Forpost.Application.Contracts.Catalogs.Products;
using Mediator;

namespace Forpost.Features.Catalogs.Products;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductModel?>
{
    private readonly IProductReadRepository _domainRepository;

    public GetProductByIdQueryHandler(IProductReadRepository domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async ValueTask<ProductModel?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) 
        => await _domainRepository.GetByIdAsync(request.Id, cancellationToken);
}

public sealed record GetProductByIdQuery(Guid Id) : IQuery<ProductModel?>;