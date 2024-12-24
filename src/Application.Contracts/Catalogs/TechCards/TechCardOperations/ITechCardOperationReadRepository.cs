using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Catalogs.TechCards.TechCardOperations;

public interface ITechCardOperationReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<TechCardOperationModel>> GetTechCardOperationsAsync(
        Guid techCardId,
        TechCardOperationFilter filter,
        CancellationToken cancellationToken);
}