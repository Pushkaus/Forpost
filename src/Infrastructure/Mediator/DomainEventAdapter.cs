using Forpost.Domain.Primitives.DomainAbstractions;
using MediatR;

namespace Forpost.Infrastructure.Mediator;

/// <summary>
/// Подсовываем доменное событие как <see cref="INotification"/>
/// </summary>
/// <typeparam name="TDomainEvent">Тип доменного события <see cref="IDomainEvent"/></typeparam>
public class DomainEventAdapter<TDomainEvent> : INotification where TDomainEvent : class
{
    public DomainEventAdapter(TDomainEvent domainEvent) => DomainEvent = domainEvent;
    
    public TDomainEvent DomainEvent { get; }
}