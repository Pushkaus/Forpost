using Forpost.Application.Contracts.ProductsDevelopments;
using MediatR;

namespace Forpost.Application.ProductCreating.ProductsDevelopments;

internal sealed class LocationDeterminationQueryHandler: IRequestHandler<LocationDeterminationProductQuery ,LocationDeterminationProduct>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public LocationDeterminationQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async Task<LocationDeterminationProduct?> Handle(LocationDeterminationProductQuery request, CancellationToken cancellationToken)
    {
        return await _productDevelopmentReadRepository.GetLocationProduct(request.ProductDevelopmentId, cancellationToken);
    }
}
public record LocationDeterminationProductQuery(Guid ProductDevelopmentId) : IRequest<LocationDeterminationProduct>;