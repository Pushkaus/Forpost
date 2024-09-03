using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.InvoiceManagement;

public sealed record InvoiceExposed(Guid InvoiceId): IDomainEvent;