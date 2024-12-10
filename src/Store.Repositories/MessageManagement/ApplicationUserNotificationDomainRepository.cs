using System.Linq.Dynamic.Core;
using AutoMapper;
using Forpost.Common.ApplicationNotifications;
using Forpost.Domain.MessagesManagement.ApplicationNotifications;
using Forpost.Store.Postgres;
using Microsoft.EntityFrameworkCore;

namespace Forpost.Store.Repositories.MessageManagement;

internal sealed class ApplicationUserNotificationDomainRepository : DomainRepository<ApplicationUserNotification>,
    IApplicationUserNotificationDomainRepository
{
    public ApplicationUserNotificationDomainRepository(ForpostContextPostgres dbContext, TimeProvider timeProvider,
        IMapper mapper) : base(dbContext, timeProvider, mapper)
    {
    }

    public async Task<IReadOnlyCollection<ApplicationUserNotification>> GetAllNotificationsByUserId(Guid userId,
        CancellationToken cancellationToken) =>
        await DbSet.Where(n => n.UserId == userId).ToListAsync(cancellationToken);

    public async Task<IReadOnlyCollection<ApplicationUserNotification>> GetAlldByNotificationName(
        string notificationName, CancellationToken cancellationToken)
    {
        return await DbSet
            .Join(DbContext.ApplicationNotifications,
                userNotification => userNotification.NotificationId,
                applicationNotification => applicationNotification.Id,
                (userNotification, applicationNotification) => new { userNotification, applicationNotification })
            .Where(joined => joined.applicationNotification.NotificationName == notificationName)
            .Select(joined => joined.userNotification)
            .ToListAsync(cancellationToken);
    }
}