using Forpost.Domain.Catalogs.Contractors.Events;
using Forpost.Domain.Primitives.EntityTemplates;

namespace Forpost.Domain.Catalogs.Contractors;

/// <summary>
/// Контрагент
/// </summary>
public sealed class Contractor : AggregateRoot
{
    public string Name { get; private set; }
    public string INN { get; private set; }
    public string Country { get; private set; }
    public string City { get; private set; }
    public string? Description { get; private set; }
    public decimal? DiscountLevel { get; private set; }
    public string? LogisticInfo { get; private set; }
    public ContractorType ContractorType { get; private set; }

    private Contractor()
    {
        
    }
    private Contractor(
        string name,
        string inn,
        string country,
        string city,
        string? description,
        decimal? discountLevel,
        string? logisticInfo,
        ContractorType contractorType)
    {
        Name = name;
        INN = inn;
        Country = country;
        City = city;
        Description = description;
        DiscountLevel = discountLevel;
        LogisticInfo = logisticInfo;
        ContractorType = contractorType;
    }

    public static Contractor Create(
        string name,
        string inn,
        string country,
        string city,
        ContractorType contractorType,
        string? description = null,
        decimal? discountLevel = null,
        string? logisticInfo = null)
    {
        var contractor =
            new Contractor(name, inn, country, city, description, discountLevel, logisticInfo, contractorType);

        contractor.Raise(new ContractorAdded(contractor.Id));
        return contractor;
    }
}