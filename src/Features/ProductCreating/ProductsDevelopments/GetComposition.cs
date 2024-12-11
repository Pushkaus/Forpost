using Forpost.Application.Contracts.ProductCreating.CompositionProduct;
using Mediator;

namespace Forpost.Features.ProductCreating.ProductsDevelopments;

internal sealed class GetCompositionByIdQueryHandler: 
    IQueryHandler<GetCompositionByIdQuery, IReadOnlyCollection<CompositionProductGroupModel>>
{
    private readonly ICompositionProductReadRepository _compositionProductReadRepository;

    public GetCompositionByIdQueryHandler(ICompositionProductReadRepository compositionProductReadRepository)
    {
        _compositionProductReadRepository = compositionProductReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<CompositionProductGroupModel>> Handle(GetCompositionByIdQuery query, CancellationToken cancellationToken)
    {
        return await _compositionProductReadRepository.GetCompositionProduct(query.ProductId, cancellationToken); 
    }
}
public record GetCompositionByIdQuery(Guid ProductId) : IQuery<IReadOnlyCollection<CompositionProductGroupModel>>;