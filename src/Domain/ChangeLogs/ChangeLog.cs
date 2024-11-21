using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.ChangeLogs;

public sealed class ChangeLog: DomainEntity
{
    public Guid EntityId { get; private set; }
    public string PropertyName { get; private set; }
    public string? OldValue { get; private set; }
    public string? NewValue { get; private set; }
    public DateTimeOffset CreatedAt { get; private set; }
    public Guid CreatedById { get; private set; }

    // Приватный конструктор для создания нового журнала изменений
    private ChangeLog(Guid entityId, string propertyName, string? oldValue, string? newValue)
    {
        EntityId = entityId;
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
    }
    public static ChangeLog Create(Guid entityId, string propertyName, object? oldValue, object? newValue)
    {
        return new ChangeLog(
            entityId, 
            propertyName, 
            oldValue?.ToString(), 
            newValue?.ToString());
    }
}