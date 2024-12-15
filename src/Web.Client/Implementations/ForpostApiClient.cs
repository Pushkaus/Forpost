namespace Forpost.Web.Client.Implementations;

public sealed class ForpostApiClient : IForpostApiClient
{
    public ForpostApiClient(IIssueClient issueClient,
        IManufacturingProcessClient manufacturingProcessClient,
        IInvoiceClient invoiceClient,
        IInvoiceProductClient invoiceProductClient, 
        ITechCardClient techCardClient,
        ITechCardStepClient techCardStepClient,
        ITechCardItemClient techCardItemClient,
        IStorageClient storageClient,
        IStepClient stepClient, 
        IRoleClient roleClient, 
        IProductClient productClient, 
        IOperationClient operationClient,
        IEmployeeClient employeeClient,
        IContractorClient contractorClient, 
        IAccountClient accountClient)
    {
        IssueClient = issueClient;
        ManufacturingProcessClient = manufacturingProcessClient;
        InvoiceClient = invoiceClient;
        InvoiceProductClient = invoiceProductClient;
        TechCardClient = techCardClient;
        TechCardStepClient = techCardStepClient;
        TechCardItemClient = techCardItemClient;
        StorageClient = storageClient;
        StepClient = stepClient;
        RoleClient = roleClient;
        ProductClient = productClient;
        OperationClient = operationClient;
        EmployeeClient = employeeClient;
        ContractorClient = contractorClient;
        AccountClient = accountClient;
    }
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