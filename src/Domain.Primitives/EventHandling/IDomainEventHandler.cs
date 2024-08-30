using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Primitives.EventHandling;

/// <summary>
/// Обработчик доменных событий
/// </summary>
/// <typeparam name="TDomainEvent">Тип доменного события <see cref="IDomainEvent"/></typeparam>
public interface IDomainEventHandler<in TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    /// <summary>
    /// Обработать доменное события
    /// </summary>
    /// <param name="domainEvent">Доменное событие</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task Handle(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}