using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;

public interface IManufacturingProcessReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel>, int TotalCount)> GetAllAsync(int skip, int limit,
        CancellationToken cancellationToken);
    
    public Task<ManufacturingProcessWithDetailsModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}