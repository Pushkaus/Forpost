using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.StorageManagement.Events;

public sealed record ProductOnStorageScanned(Guid ProductId, Guid StorageId, int Quantity) : IDomainEvent;
