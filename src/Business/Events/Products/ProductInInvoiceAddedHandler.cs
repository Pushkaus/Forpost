using System.Diagnostics;
using Forpost.Business.EventHanding;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Events.Products;

internal sealed class ProductInInvoiceAddedHandler : IDomainEventHandler<ProductInInvoiceAdded>, 
    IDomainEventHandler<ProductInInvoiceAdded2>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ILogger<ProductInInvoiceAddedHandler> _logger;

    public ProductInInvoiceAddedHandler(IEmployeeRepository employeeRepository,
        ILogger<ProductInInvoiceAddedHandler> logger)
    {
        _employeeRepository = employeeRepository;
        _logger = logger;
    }
    
    public async Task HandleAsync(ProductInInvoiceAdded domainEvent, CancellationToken cancellationToken = default)
    {
        var employees = await _employeeRepository.GetAllAsync();

        foreach (var employee in employees)
        {
            Debug.WriteLine($"{employee.LastName} найден");
        }
    }
    
    public async Task HandleAsync(ProductInInvoiceAdded2 domainEvent, CancellationToken cancellationToken = default)
    {
        Debug.WriteLine($"Я из {nameof(ProductInInvoiceAddedHandler)}");

        await Task.CompletedTask;
    }
}