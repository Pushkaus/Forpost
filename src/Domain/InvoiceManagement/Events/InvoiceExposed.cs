using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.InvoiceManagement.Events;

public sealed record InvoiceExposed(Guid InvoiceId): IDomainEvent;