using Forpost.Application.Contracts.MessageManagement.ApplicationNotifications;
using Forpost.Common.ApplicationNotifications;
using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.Application;

internal sealed class ApplicationNotificationReadRepository : IApplicationNotificationReadRepository
{
    private readonly ForpostContextPostgres _dbContext;

    public ApplicationNotificationReadRepository(ForpostContextPostgres dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyCollection<ApplicationNotification>>
        GetApplicationNotificationsAsync(CancellationToken cancellationToken) =>
        await _dbContext.ApplicationNotifications.ToListAsync(cancellationToken);
}