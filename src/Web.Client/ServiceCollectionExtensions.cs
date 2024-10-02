using Forpost.Web.Client.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Web.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddForpostClients(this IServiceCollection services, Func<HttpClient> client)
    {
        services.AddHttpClient<IIssueClient, IssueClient>(nameof(IssueClient), _ => new IssueClient(client.Invoke()));
        services.AddHttpClient<IManufacturingProcessClient, ManufacturingProcessClient>(nameof(ManufacturingProcessClient), _ => new ManufacturingProcessClient(client.Invoke()));
        services.AddHttpClient<IInvoiceClient, InvoiceClient>(nameof(InvoiceClient), _ => new InvoiceClient(client.Invoke()));
        services.AddHttpClient<IInvoiceProductClient, InvoiceProductClient>(nameof(InvoiceProductClient), _ => new InvoiceProductClient(client.Invoke()));
        services.AddHttpClient<ICompositionTechCardClient, CompositionTechCardClient>(nameof(CompositionTechCardClient), _ => new CompositionTechCardClient(client.Invoke()));
        services.AddHttpClient<ITechCardStepClient, TechCardStepClient>(nameof(TechCardStepClient), _ => new TechCardStepClient(client.Invoke()));
        services.AddHttpClient<ITechCardItemClient, TechCardItemClient>(nameof(TechCardItemClient), _ => new TechCardItemClient(client.Invoke()));
        services.AddHttpClient<IStorageClient, StorageClient>(nameof(StorageClient), _ => new StorageClient(client.Invoke()));
        services.AddHttpClient<IStepClient, StepClient>(nameof(StepClient), _ => new StepClient(client.Invoke()));
        services.AddHttpClient<IRoleClient, RoleClient>(nameof(RoleClient), _ => new RoleClient(client.Invoke()));
        services.AddHttpClient<IProductClient, ProductClient>(nameof(ProductClient), _ => new ProductClient(client.Invoke()));
        services.AddHttpClient<IOperationClient, OperationClient>(nameof(OperationClient), _ => new OperationClient(client.Invoke()));
        services.AddHttpClient<IEmployeeClient, EmployeeClient>(nameof(EmployeeClient), _ => new EmployeeClient(client.Invoke()));
        services.AddHttpClient<IContractorClient, ContractorClient>(nameof(ContractorClient), _ => new ContractorClient(client.Invoke()));
        services.AddHttpClient<IAccountClient, AccountClient>(nameof(AccountClient), _ => new AccountClient(client.Invoke()));
        
        services.AddSingleton<IForpostApiClient, ForpostApiClient>();
        return services;
    }
}
