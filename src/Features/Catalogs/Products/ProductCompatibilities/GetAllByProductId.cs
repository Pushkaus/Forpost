using Forpost.Application.Contracts.Catalogs.Products.ProductCompatibilities;
using Forpost.Domain.Catalogs.Products.ProductCompatibilities;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductCompatibilities;

internal sealed class GetAllCompatibilitiesByProductIdQueryHandler : IQueryHandler<GetAllCompatibilitiesByProductIdQuery
    , IReadOnlyCollection<ProductCompatibilityModel>>
{
    private readonly IProductCompatibilityReadRepository _productCompatibilityReadRepository;

    public GetAllCompatibilitiesByProductIdQueryHandler(
        IProductCompatibilityReadRepository productCompatibilityReadRepository)
    {
        _productCompatibilityReadRepository = productCompatibilityReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<ProductCompatibilityModel>> Handle(GetAllCompatibilitiesByProductIdQuery query,
        CancellationToken cancellationToken) =>
        await _productCompatibilityReadRepository.GetAllProductCompatibilityAsync(query.ProductId,
            cancellationToken);
}

public record GetAllCompatibilitiesByProductIdQuery(Guid ProductId)
    : IQuery<IReadOnlyCollection<ProductCompatibilityModel>>;