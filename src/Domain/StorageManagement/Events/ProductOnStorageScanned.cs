using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.StorageManagment.Events;

public sealed record ProductOnStorageScanned(Guid ProductId, Guid StorageId, int Quantity) : IDomainEvent;
