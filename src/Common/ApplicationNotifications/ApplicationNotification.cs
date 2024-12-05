namespace Forpost.Common.ApplicationNotifications;

public sealed class ApplicationNotification
{
    public Guid Id { get; set; }
    public string NotificationName { get; set; } = string.Empty;
}