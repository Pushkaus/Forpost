using Forpost.Web.Client.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Web.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddForpostClients(this IServiceCollection services)
    {
        services.AddHttpClient<IIssueClient, IssueClient>();
        services.AddHttpClient<IManufacturingProcessClient, ManufacturingProcessClient>();
        services.AddHttpClient<IInvoiceClient, InvoiceClient>();
        services.AddHttpClient<IInvoiceProductClient, InvoiceProductClient>();
        services.AddHttpClient<IInvoiceProductClient, InvoiceProductClient>();
        services.AddHttpClient<ITechCardClient, TechCardClient>();
        services.AddHttpClient<ITechCardStepClient, TechCardStepClient>();
        services.AddHttpClient<ITechCardItemClient, TechCardItemClient>();
        services.AddHttpClient<IStorageClient, StorageClient>();
        services.AddHttpClient<IStepClient, StepClient>();
        services.AddHttpClient<IRoleClient, RoleClient>();
        services.AddHttpClient<IProductClient, ProductClient>();
        services.AddHttpClient<IOperationClient, OperationClient>();
        services.AddHttpClient<IEmployeeClient, EmployeeClient>();
        services.AddHttpClient<IContractorClient, ContractorClient>();
        services.AddHttpClient<IAccountClient, AccountClient>();
        services.AddHttpClient<IContractorClient, ContractorClient>();
        
        services.AddSingleton<IForpostApiClient, ForpostApiClient>();
        return services;
    }
}