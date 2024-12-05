namespace Forpost.Application.Contracts.MessageManagement;

public sealed class NotificationForUsersModel
{
    public Guid Id { get; set; }
    public string Message { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
}