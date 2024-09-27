using Forpost.Application.Contracts.ProductCreating.CompletedProducts;
using Mediator;

namespace Forpost.Features.ProductCreating.CompletedProducts;

internal sealed class GetAllOnStorageQueryHandler :
    IQueryHandler<GetAllOnStorageQuery, (IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)>
{
    private readonly ICompletedProductReadRepository _completedProductReadRepository;

    public GetAllOnStorageQueryHandler(ICompletedProductReadRepository completedProductReadRepository)
    {
        _completedProductReadRepository = completedProductReadRepository;
    }

    public async ValueTask<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)>
        Handle(GetAllOnStorageQuery query, CancellationToken cancellationToken)
    {
        var result = await _completedProductReadRepository.GetAllOnStorage(query.FilterExpression, query.FilterValues,
            query.Skip, query.Limit, cancellationToken);
        return result;
    }
}

public record GetAllOnStorageQuery(
    string? FilterExpression,
    object?[]? FilterValues,
    int Skip,
    int Limit) :
    IQuery<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)>;