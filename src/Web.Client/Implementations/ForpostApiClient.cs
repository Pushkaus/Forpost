namespace Forpost.Web.Client.Implementations;

public sealed class ForpostApiClient : IForpostApiClient
{
    public ForpostApiClient(IIssueClient issueClient,
        IManufacturingProcessClient manufacturingProcessClient,
        IInvoiceClient invoiceClient,
        IInvoiceProductClient invoiceProductClient, 
        ITechCardClient techCardClient,
        ITechCardItemClient techCardItemClient,
        IStorageClient storageClient,
        IRoleClient roleClient, 
        IProductClient productClient, 
        IOperationClient operationClient,
        IEmployeeClient employeeClient,
        IContractorClient contractorClient, 
        IAccountClient accountClient, IApplicationNotificationClient applicationNotificationClient, IManufacturingOrderClient manufacturingOrderClient, IManufacturingOrderCompositionClient manufacturingOrderCompositionClient)
    {
        IssueClient = issueClient;
        ManufacturingProcessClient = manufacturingProcessClient;
        InvoiceClient = invoiceClient;
        InvoiceProductClient = invoiceProductClient;
        TechCardClient = techCardClient;
        TechCardItemClient = techCardItemClient;
        StorageClient = storageClient;
        RoleClient = roleClient;
        ProductClient = productClient;
        OperationClient = operationClient;
        EmployeeClient = employeeClient;
        ContractorClient = contractorClient;
        AccountClient = accountClient;
        ApplicationNotificationClient = applicationNotificationClient;
        ManufacturingOrderClient = manufacturingOrderClient;
        ManufacturingOrderCompositionClient = manufacturingOrderCompositionClient;
    }

    public IApplicationNotificationClient ApplicationNotificationClient { get; }
    
    public IManufacturingOrderClient ManufacturingOrderClient { get; }
    
    public IManufacturingOrderCompositionClient ManufacturingOrderCompositionClient { get; }

    public IIssueClient IssueClient { get; }
    
    public IManufacturingProcessClient ManufacturingProcessClient { get; }
    
    public IInvoiceClient InvoiceClient { get; }
    
    public IInvoiceProductClient InvoiceProductClient { get; }
    
    public ITechCardClient TechCardClient { get; }
    
    public ITechCardItemClient TechCardItemClient { get; }
    
    public IStorageClient StorageClient { get; }
    
    public IRoleClient RoleClient { get; }
    
    public IProductClient ProductClient { get; }
    
    public IOperationClient OperationClient { get; }
    
    public IEmployeeClient EmployeeClient { get; }
    
    public IContractorClient ContractorClient { get; }
    
    public IAccountClient AccountClient { get; }
}