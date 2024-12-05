namespace Forpost.Web.Contracts.MessageManagement.ApplicationNotifications;

public sealed class SubscribeUserToNotificationRequest
{
    public Guid UserId { get; set; }
    public Guid NotificationId { get; set; }
}