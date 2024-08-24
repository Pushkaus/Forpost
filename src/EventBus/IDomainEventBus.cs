namespace Forpost.EventBus;

public interface IDomainEventBus
{
    public Task PublishAsync<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : class, IDomainEvent;
}