namespace Forpost.Web.Contracts.MessageManagement.ApplicationNotifications;

public sealed class NotificationsByUserIdRequest
{
    public Guid UserId { get; set; }
}