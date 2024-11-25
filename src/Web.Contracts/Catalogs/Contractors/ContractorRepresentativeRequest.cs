namespace Forpost.Web.Contracts.Catalogs.Contractors;

public sealed class ContractorRepresentativeRequest
{
    public Guid ContractorId { get; set; }
    public string Name { get; set; }
    public string? Post { get; set; }
    public string? Description { get; set; }
}