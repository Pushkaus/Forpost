namespace Forpost.Application.Contracts.Changes;

public sealed class ChangeHistoryModel
{
    public Guid Id { get; set; }
    public Guid EntityId { get; set; }
    public string EntityName { get; set; }
    public string PropertyName { get; set; }
    public string Value { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public Guid UpdatedById { get; set; }
    public string UpdatedByName { get; set; }
}