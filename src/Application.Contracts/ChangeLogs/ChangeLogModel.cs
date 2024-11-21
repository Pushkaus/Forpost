namespace Forpost.Application.Contracts.ChangeLogs;

public sealed class ChangeLogModel
{
    public Guid Id { get; set; }
    public Guid EntityId { get; set; }
    public string PropertyName { get; set; }
    public string? OldValue { get; set; }
    public string? NewValue { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public string CreatedBy { get; set; }
}