using Forpost.Common.DataAccess;
using Forpost.Domain.Catalogs.TechCardItems;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Application.Contracts.ProductsDevelopments;

public interface IProductDevelopmentReadRepository: IApplicationReadRepository
{
    public Task<InizializationProductDevelopment?>
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken);
    
    public Task<IReadOnlyCollection<TechCardItem>>
        GetTechCardItemsById(Guid productDevelopmentId, CancellationToken cancellationToken);
}