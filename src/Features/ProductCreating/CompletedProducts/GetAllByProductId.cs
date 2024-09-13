using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Forpost.Domain.ProductCreating.CompletedProduct;
using Mediator;

namespace Forpost.Features.ProductCreating.CompletedProducts;

internal sealed class GetAllByProductIdQueryHandler: IQueryHandler<GetAllByProductIdQuery, IReadOnlyCollection<CompletedProductModel>>
{
    private readonly ICompletedProductReadRepository _completedProductReadRepository;

    public GetAllByProductIdQueryHandler(ICompletedProductReadRepository completedProductReadRepository)
    {
        _completedProductReadRepository = completedProductReadRepository;
    }

    public async ValueTask<IReadOnlyCollection<CompletedProductModel>> 
        Handle(GetAllByProductIdQuery query, CancellationToken cancellationToken)
    {
        return await _completedProductReadRepository.GetAllByProductId(query.ProductId, cancellationToken);
    }
}
public record GetAllByProductIdQuery(Guid ProductId) : IQuery<IReadOnlyCollection<CompletedProductModel>>;