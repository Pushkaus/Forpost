using Forpost.Common.ApplicationNotifications;
using Forpost.Common.DataAccess;

namespace Forpost.Application.Contracts.MessageManagement.ApplicationNotifications;

public interface IApplicationNotificationReadRepository : IApplicationReadRepository
{
    public Task<IReadOnlyCollection<ApplicationNotification>> GetApplicationNotificationsAsync(
        CancellationToken cancellationToken);
}