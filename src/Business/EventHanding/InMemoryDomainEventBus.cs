using System.Collections.Concurrent;

namespace Forpost.Business.EventHanding;

internal sealed class InMemoryDomainEventBus : IDomainEventBus
{
    private readonly ConcurrentDictionary<Type, List<IDomainEventHandler>> _eventHandlerCache = new();

    public InMemoryDomainEventBus(IEnumerable<IDomainEventHandler> handlers)
    {
        foreach (var handler in handlers)
        {
            var handlerType = handler.GetType();

            var eventTypes = handlerType
                .GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDomainEventHandler<>))
                .Select(i => i.GetGenericArguments()[0])
                .ToList();

            foreach (var eventType in eventTypes)
                _eventHandlerCache.AddOrUpdate(
                    eventType,
                    _ => [handler],
                    (_, existingHandlers) => existingHandlers.Append(handler).ToList());
        }
    }

    public async Task PublishAsync<TDomainEvent>(TDomainEvent domainEvent,
        CancellationToken cancellationToken = default)
        where TDomainEvent : class, IDomainEvent
    {
        if (_eventHandlerCache.TryGetValue(typeof(TDomainEvent), out var handlers))
        {
            var typedHandlers = handlers.Cast<IDomainEventHandler<TDomainEvent>>();
            await Task.WhenAll(typedHandlers
                .Select(handler => handler.HandleAsync(domainEvent, cancellationToken)));
        }
    }
}