using Forpost.Application.Contracts.ProductsDevelopments;
using Forpost.Common.DataAccess;
using Forpost.Domain.Catalogs.TechCardItems;

namespace Forpost.Application.Contracts.ProductCreating.ProductsDevelopments;

public interface IProductDevelopmentReadRepository: IApplicationReadRepository
{
    public Task<InizializationProductDevelopment?>
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken);
    
    public Task<IReadOnlyCollection<TechCardItem>>
        GetTechCardItemsById(Guid productDevelopmentId, CancellationToken cancellationToken);

    public Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>
        GetAllByIssueId(Guid issueId, CancellationToken cancellationToken, int skip, int limit);
    
    public Task<(IReadOnlyCollection<ProductDevelopmentModel> ProductDevelopments, int TotalCount)>
        GetAllAsync(CancellationToken cancellationToken, int skip, int limit);
}