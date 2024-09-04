using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.ProductCreating.ManufacturingProcesses;

public sealed record ManufacturingProcessLaunched(Guid ManufacturingProcessId): IDomainEvent
{
    
}