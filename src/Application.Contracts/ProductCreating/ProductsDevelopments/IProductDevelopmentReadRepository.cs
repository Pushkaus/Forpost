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
    
    public Task<IReadOnlyCollection<ProductDevelopmentDetails>> 
        GetAllByIssueId(Guid issueId, CancellationToken cancellationToken);
}