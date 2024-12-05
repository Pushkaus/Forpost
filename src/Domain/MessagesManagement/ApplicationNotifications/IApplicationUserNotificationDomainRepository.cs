using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.MessagesManagement.ApplicationNotifications;

public interface IApplicationUserNotificationDomainRepository : IDomainRepository<ApplicationUserNotification>
{
    public Task<IReadOnlyCollection<ApplicationUserNotification>> GetAllNotificationsByUserId(Guid userId,
        CancellationToken cancellationToken);
}