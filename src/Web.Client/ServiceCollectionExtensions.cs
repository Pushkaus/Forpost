using Forpost.Web.Client.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Web.Client;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddForpostClients(this IServiceCollection services)
    {
        var baseAddress = new Uri(BaseConstants.BaseUrl);
        
        services.AddHttpClient<IIssueClient, IssueClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IManufacturingProcessClient, ManufacturingProcessClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IInvoiceClient, InvoiceClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IInvoiceProductClient, InvoiceProductClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<ITechCardClient, TechCardClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<ITechCardStepClient, TechCardStepClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<ITechCardItemClient, TechCardItemClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IStorageClient, StorageClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IStepClient, StepClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IRoleClient, RoleClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IProductClient, ProductClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IOperationClient, OperationClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IEmployeeClient, EmployeeClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IContractorClient, ContractorClient>(client => client.BaseAddress = baseAddress);
        services.AddHttpClient<IAccountClient, AccountClient>(client => client.BaseAddress = baseAddress);
        
        services.AddSingleton<IForpostApiClient, ForpostApiClient>();
        return services;
    }
}