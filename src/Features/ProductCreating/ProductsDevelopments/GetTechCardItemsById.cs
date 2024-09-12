using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.Catalogs.TechCardItems;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetTechCardItemsByIdQueryHandler: 
    IQueryHandler<GetTechCardItemsByIdQuery, IReadOnlyCollection<TechCardItem>>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public GetTechCardItemsByIdQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCardItem>> 
        Handle(GetTechCardItemsByIdQuery query, CancellationToken cancellationToken)
    {
        return await _productDevelopmentReadRepository.GetTechCardItemsById(query.ProductDevelopmentId, cancellationToken);
    }
}
public record GetTechCardItemsByIdQuery(Guid ProductDevelopmentId) : IQuery<IReadOnlyCollection<TechCardItem>>;