using Forpost.Domain.Catalogs.Contractors;

namespace Forpost.Application.Contracts.Catalogs.Contractors;

public sealed class ContractorFilter
{
    public string? Name { get; set; }
    public int? ContractTypeValue { get; set; }
    public int Skip { get; set; }
    public int Limit { get; set; }
}