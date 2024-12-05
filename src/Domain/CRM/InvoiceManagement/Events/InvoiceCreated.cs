using Forpost.Common.ApplicationNotifications;
using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.CRM.InvoiceManagement.Events;

public sealed record InvoiceCreated(Guid InvoiceId): IDomainEvent, IApplicationNotification;