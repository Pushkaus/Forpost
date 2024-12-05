using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.MessagesManagement.ApplicationNotifications;

public sealed class ApplicationUserNotification: DomainEntity
{
    public Guid UserId { get; private set; }
    public Guid NotificationId { get; private set; }

    private ApplicationUserNotification(
        Guid userId,
        Guid notificationId)
    {
        UserId = userId;
        NotificationId = notificationId;
    }

    public static ApplicationUserNotification Create(Guid userId, Guid notificationId) 
        => new(userId, notificationId);
}