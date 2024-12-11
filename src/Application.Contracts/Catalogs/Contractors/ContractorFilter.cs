namespace Forpost.Application.Contracts.Catalogs.Contractors;

public sealed class ContractorFilter
{
    public string? Name { get; set; }
    public int? ContractorTypeValue { get; set; }
    public int Skip { get; set; }
    public int Limit { get; set; }
}