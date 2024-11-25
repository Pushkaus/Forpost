using Forpost.Common.DataAccess;
using Forpost.Store.Postgres;

namespace Forpost.Application.Contracts.Changes;

public interface IChangeHistoryReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<ChangeHistoryModel>> GetChangeLogsByIdAsync(Guid id, ChangeLogFilter filter,
        CancellationToken cancellationToken);
} 