using Forpost.Domain.Primitives.DomainAbstractions;

namespace Forpost.Domain.Catalogs.Contractors;

public sealed class ContractorType : SmartEnumeration<ContractorType>
{
    public static readonly ContractorType NotType = new(nameof(NotType), 0);
    public static readonly ContractorType DirectClient = new(nameof(DirectClient), 100);
    public static readonly ContractorType Dealer = new(nameof(Dealer), 200);
    public static readonly ContractorType Partner = new(nameof(Partner), 300);
    public static readonly ContractorType Provider = new(nameof(Provider), 400);
    public static readonly ContractorType Distributor = new(nameof(Distributor), 500);
    public static readonly ContractorType Integrator = new(nameof(Integrator), 600);
    public static readonly ContractorType Agent = new(nameof(Agent), 700);
    public static readonly ContractorType Customer = new(nameof(Customer), 800);
    
    public ContractorType(string name, int value) :
        base(name, value)
    {
    }
}