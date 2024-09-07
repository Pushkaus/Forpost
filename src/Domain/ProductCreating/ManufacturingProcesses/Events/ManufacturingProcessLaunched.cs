using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.ManufacturingProcesses.Events;

public sealed record ManufacturingProcessLaunched(Guid ManufacturingProcessId): IDomainEvent
{
    
}