using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.Changes;

public interface IChangeHistoryReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<ChangeHistoryModel>> GetChangeLogsByIdAsync(Guid id, ChangeLogFilter filter,
        CancellationToken cancellationToken);
} 