using Forpost.Common.DataAccess;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Application.Contracts.ProductsDevelopments;

public interface IProductDevelopmentReadRepository: IApplicationReadRepository
{
    public Task<ProductDevelopmentSummary?>
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken);
}