using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.ChangeLogs;

public interface IChangeLogReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<ChangeLogModel>> GetChangeLogsByIdAsync(Guid id, ChangeLogFilter filter,
        CancellationToken cancellationToken);
}