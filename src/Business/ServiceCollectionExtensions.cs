using Forpost.Business.Abstract.Services;
using Forpost.Business.Services;
using Forpost.Store.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Forpost.Business;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddTransient<IAccountService, AccountService>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IEmployeeService, EmployeeService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IRoleRepository, RoleRepository>();
        services.AddTransient<IInvoiceService, InvoiceService>();
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IProductOperationService, ProductOperationService>();
        services.AddTransient<IProductOperationRepository, ProductOperationRepository>();
        services.AddTransient<IInvoiceProductRepository, InvoiceProductRepository>();
        services.AddTransient<IInvoiceProductService, InvoiceProductService>();
        services.AddTransient<IStorageRepository, StorageRepository>();
        services.AddTransient<IStorageService, StorageService>();
        services.AddTransient<IStorageProductService, StorageProductService>();
        services.AddTransient<IStorageProductRepository, StorageProductRepository>();
        services.AddTransient<ISubProductRepository, SubProductRepository>();
        services.AddTransient<ISubProductService, SubProductService>();
        services.AddTransient<IContragentRepository, ContragentRepository>();
        services.AddTransient<IContragentService, ContragentService>();
        services.AddTransient<IFilesService, FilesService>();
        services.AddTransient<IFilesRepository, FileRepository>();
        return services;
    }
    
}