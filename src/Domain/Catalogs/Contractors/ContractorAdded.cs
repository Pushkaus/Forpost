using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.Contractors;

/// <summary>
/// Контрагент создан
/// </summary>
/// <param name="ContractorId">Ид контрагента</param>
public sealed record ContractorAdded(Guid ContractorId) : IDomainEvent;
