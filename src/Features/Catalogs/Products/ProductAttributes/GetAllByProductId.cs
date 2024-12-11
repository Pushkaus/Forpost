using Forpost.Application.Contracts.Catalogs.Products.ProductAttributes;
using Forpost.Domain.Catalogs.Products.ProductAttributes;
using Mediator;

namespace Forpost.Features.Catalogs.Products.ProductAttributes;

internal sealed class GetAllAttributesByProductIdQueryHandler : IQueryHandler<GetAllAttributesByProductIdQuery,
    IReadOnlyCollection<ProductAttributeModel>>
{
    private readonly IProductAttributeReadRepository _productAttributeReadRepository;

    public GetAllAttributesByProductIdQueryHandler(IProductAttributeReadRepository productAttributeReadRepository)
    {
        _productAttributeReadRepository = productAttributeReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<ProductAttributeModel>> Handle(GetAllAttributesByProductIdQuery query,
        CancellationToken cancellationToken) =>
        await _productAttributeReadRepository.GetAllAttributesByProductIdAsync(query.ProductId,
            cancellationToken);
}

public record GetAllAttributesByProductIdQuery(Guid ProductId) : IQuery<IReadOnlyCollection<ProductAttributeModel>>;