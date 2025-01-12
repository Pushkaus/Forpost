using Forpost.Common.ApplicationNotifications;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Crm.InvoiceManagement.Events;

public sealed record InvoiceCreated(Guid InvoiceId): IDomainEvent, IApplicationNotification;