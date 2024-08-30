using Forpost.Domain.Primitives.DomainAbstractions;
using Forpost.Domain.Primitives.EventHandling;
using MediatR;

namespace Forpost.Infrastructure.Mediator;

/// <summary>
/// Подсовываем издателя доменных событий как <see cref="IPublisher"/>
/// </summary>
internal sealed class DomainEventPublisherAdapter : IDomainEventPublisher
{
    private readonly IPublisher _publisher;

    public DomainEventPublisherAdapter(IPublisher publisher) => _publisher = publisher;

    public async Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default) 
        where TDomainEvent : class, IDomainEvent
    {
        var domainEventAsNotification = new DomainEventAdapter<TDomainEvent>(domainEvent);
        await _publisher.Publish(domainEventAsNotification, cancellationToken);
    }
}