using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.CompositionCompletedProducts;

public interface ICompositionCompletedProductReadRepository: IApplicationReadRepository
{
    public Task<IReadOnlyCollection<CompositionCompletedProductWithSummary>> GetCompositionCompletedProductWithSummaryAsync(Guid completedProductId, CancellationToken cancellationToken);
}