using Forpost.Application.Contracts.Catalogs.TechCards;
using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Common.DataAccess;
using Forpost.Domain.Catalogs.TechCardItems;

namespace Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;

public interface IProductDevelopmentReadRepository: IApplicationReadRepository
{
    public Task<InizializationProductDevelopment?>
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken);
    
    public Task<IReadOnlyCollection<TechCardItemModel>>
        GetTechCardItemsByProductDevelopmentId(Guid productDevelopmentId, CancellationToken cancellationToken);

    public Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>
        GetAllByIssueId(Guid issueId, CancellationToken cancellationToken, int skip, int limit);
    
    public Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>
        GetAllAsync(
            string? filterExpression, object?[]? filterValues, int skip, int limit, CancellationToken cancellationToken);
}