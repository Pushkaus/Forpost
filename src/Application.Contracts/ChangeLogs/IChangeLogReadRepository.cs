using Forpost.Common.DataAccess;
using Forpost.Domain.ChangeLogs;

namespace Forpost.Application.Contracts.ChangeLogs;

public interface IChangeLogReadRepository: IApplicationReadRepository
{
    public Task<EntityPagedResult<ChangeLog>> GetChangeLogsByIdAsync(Guid id, ChangeLogFilter filter,
        CancellationToken cancellationToken);
}