using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Primitives.EventHandling;

/// <summary>
/// Издатель доменных событий
/// </summary>
public interface IDomainEventPublisher
{
    /// <summary>
    /// Опубликовать событие
    /// </summary>
    /// <param name="domainEvent">Тип доменного события</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <typeparam name="TDomainEvent">Тип доменного события <see cref="IDomainEvent"/></typeparam>
    Task Publish<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default)
        where TDomainEvent : class, IDomainEvent;
}