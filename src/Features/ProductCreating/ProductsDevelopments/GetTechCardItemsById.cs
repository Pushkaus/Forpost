using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Domain.Catalogs.TechCardItems;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetTechCardItemsByIdQueryHandler: 
    IQueryHandler<GetTechCardItemsByIdQuery, IReadOnlyCollection<TechCardItemModel>>
{
    private readonly IProductDevelopmentReadRepository _productDevelopmentReadRepository;

    public GetTechCardItemsByIdQueryHandler(IProductDevelopmentReadRepository productDevelopmentReadRepository)
    {
        _productDevelopmentReadRepository = productDevelopmentReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<TechCardItemModel>> 
        Handle(GetTechCardItemsByIdQuery query, CancellationToken cancellationToken)
    {
        return await _productDevelopmentReadRepository.GetTechCardItemsByProductDevelopmentId(query.ProductDevelopmentId, cancellationToken);
    }
}
public record GetTechCardItemsByIdQuery(Guid ProductDevelopmentId) : IQuery<IReadOnlyCollection<TechCardItemModel>>;