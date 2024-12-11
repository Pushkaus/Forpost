using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.CompletedProducts;

public interface ICompletedProductReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<CompletedProductModel>> GetAllByProductId(Guid productId,
        CancellationToken cancellationToken);

    public Task<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)>
        GetAllOnStorage(
            string? filterExpression, object?[]? filterValues, int skip, int limit,
            CancellationToken cancellationToken);
    
    public Task<(IReadOnlyCollection<CompletedProductModel> CompletedProducts, int TotalCount)>
        GetAll(
            string? filterExpression, object?[]? filterValues, int skip, int limit,
            CancellationToken cancellationToken);
    

}