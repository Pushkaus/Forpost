using Forpost.Domain.Catalogs.Contractors;

namespace Forpost.Application.Contracts.Catalogs.Contractors;

public sealed class ContractorModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string INN { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string? Description { get; set; }
    public decimal? DiscountLevel { get; set; }
    public string? LogisticInfo { get; set; }
    public ContractorType ContractType { get; set; }
}