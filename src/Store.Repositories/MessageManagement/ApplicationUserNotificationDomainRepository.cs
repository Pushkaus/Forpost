using AutoMapper;
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
}