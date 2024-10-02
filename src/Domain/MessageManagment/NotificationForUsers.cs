using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.MessageManager;

public sealed class NotificationForUsers: DomainAuditableEntity
{
    public static NotificationForUsers Publish(string message)
    {
        var notificationForUsers = new NotificationForUsers()
        {
            Message = message
        };
        return notificationForUsers;
    }
    
    public string Message { get; set; } = null!;
}