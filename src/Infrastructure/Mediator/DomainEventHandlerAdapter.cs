using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EventHandling;
using MediatR;

namespace Forpost.Infrastructure.Mediator;

public sealed class DomainEventHandlerAdapter<TDomainEvent> : INotificationHandler<DomainEventAdapter<TDomainEvent>> where TDomainEvent : class, IDomainEvent
{
    private readonly IEnumerable<IDomainEventHandler<TDomainEvent>> _handlers;

    public DomainEventHandlerAdapter(IEnumerable<IDomainEventHandler<TDomainEvent>> handlers) => 
        _handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
    
    public async Task Handle(DomainEventAdapter<TDomainEvent> notification, CancellationToken cancellationToken)
    {
        var type = typeof(TDomainEvent);
        var handlingTasks = _handlers
            .Select(domainEventHandler => 
                domainEventHandler.Handle(notification.DomainEvent, cancellationToken)); 
        
        await Task.WhenAll(handlingTasks);
    }
}