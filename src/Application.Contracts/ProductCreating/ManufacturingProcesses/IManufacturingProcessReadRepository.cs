using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ProductCreating.ManufacturingProcesses;

public interface IManufacturingProcessReadRepository: IApplicationReadRepository
{
    public Task<(IReadOnlyCollection<ManufacturingProcessWithDetailsModel> ManufacturingProcesses, int TotalCount)> GetAllAsync(
        string? filterExpression, object?[]? filterValues, int skip, int limit, CancellationToken cancellationToken);
    
    public Task<ManufacturingProcessWithDetailsModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}