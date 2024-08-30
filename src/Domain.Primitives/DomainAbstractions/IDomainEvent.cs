using MediatR;

namespace Forpost.Domain.Primitives.DomainAbstractions;

/// <summary>
/// Маркерный интерфейс доменных событий
/// </summary>
// TODO: избавить доменный слой от Mediatr
public interface IDomainEvent : INotification;