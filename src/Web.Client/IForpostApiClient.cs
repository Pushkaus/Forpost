using Forpost.Web.Client.Implementations;

namespace Forpost.Web.Client;

/// <summary>
/// Собиратель всех клиентов для удобства
/// </summary>
public interface IForpostApiClient
{
    public IIssueClient IssueClient { get; }
    
    public IManufacturingProcessClient ManufacturingProcessClient { get; }
    
    public IInvoiceClient InvoiceClient { get; }
    
    public IInvoiceProductClient InvoiceProductClient { get; }
    
    public ITechCardClient TechCardClient { get; }
    
    public ITechCardStepClient TechCardStepClient { get; }
    
    public ITechCardItemClient TechCardItemClient { get; }
    
    public IStorageClient StorageClient { get; }
    
    public IStepClient StepClient { get; }
    
    public IRoleClient RoleClient { get; }
    
    public IProductClient ProductClient { get; }
    
    public IOperationClient OperationClient { get; }
    
    public IEmployeeClient EmployeeClient { get; }
    
    public IContractorClient ContractorClient { get; }
    
    public IAccountClient AccountClient { get; }
}