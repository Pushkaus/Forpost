namespace Forpost.Business.EventHanding;

/// <summary>
/// Обработчик доменного события
/// </summary>
/// <typeparam name="TDomainEvent">Тип доменного события</typeparam>
public interface IDomainEventHandler<in TDomainEvent> : IDomainEventHandler where TDomainEvent: IDomainEvent
{
    /// <summary>
    /// Обработать событие
    /// </summary>
    /// <param name="domainEvent">Событие</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public Task HandleAsync(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
}