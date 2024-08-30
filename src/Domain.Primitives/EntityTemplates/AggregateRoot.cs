using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Primitives.EntityTemplates;

/// <summary>
/// Корень агрегата
/// </summary>
/// <remarks>Только корневые сущности могут вызывать события. Все корневые сущности будут Auditable</remarks>
public abstract class AggregateRoot : DomainAuditableEntity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    /// <summary>
    /// Список доменных событий
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();
    
    /// <summary>
    /// Очистить доменные события
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    /// <summary>
    /// Вызвать доменное событие
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    protected void Raise(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}