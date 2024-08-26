using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductsDevelopments;

public interface IProductDevelopmentReadRepository: IApplicationReadRepository
{
    public Task<ProductDevelopmentSummary?>
        GetSummaryByManufacturingProcessIdAsync(Guid manufacturingProcessId, CancellationToken cancellationToken);
}