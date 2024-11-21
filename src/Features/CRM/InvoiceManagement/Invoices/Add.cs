using System.Collections.ObjectModel;
using FluentValidation;
using Forpost.Domain.CRM.InvoiceManagement;
using Forpost.Domain.CRM.InvoiceManagement.Contracts;
using Mediator;
using Microsoft.Extensions.Logging;

namespace Forpost.Features.CRM.InvoiceManagement.Invoices;

internal sealed class AddInvoiceCommandHandler : ICommandHandler<AddInvoiceCommand, Guid>
{
    private readonly IInvoiceDomainRepository _invoiceDomainRepository;
    private readonly IInvoiceProductDomainRepository _invoiceProductDomainRepository;
    private readonly ILogger<AddInvoiceCommandHandler> _logger;
    private readonly IValidator<AddInvoiceCommand> _validator;

    public AddInvoiceCommandHandler(IInvoiceDomainRepository invoiceDomainRepository,
        IInvoiceProductDomainRepository invoiceProductDomainRepository, ILogger<AddInvoiceCommandHandler> logger,
        IValidator<AddInvoiceCommand> validator)
    {
        _invoiceDomainRepository = invoiceDomainRepository;
        _invoiceProductDomainRepository = invoiceProductDomainRepository;
        _logger = logger;
        _validator = validator;
    }

    public ValueTask<Guid> Handle(AddInvoiceCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);

        var invoice = Invoice.Create(
            command.Number,
            command.ContractorId,
            command.Description,
            command.Priority,
            command.PaymentStatus,
            command.PaymentDeadline,
            command.CreateDate);
        
        if (command.PaymentPercentage.HasValue)
        {
            invoice.SetPaymentPercentage(command.PaymentPercentage.Value);
        }
        
        var invoiceId = _invoiceDomainRepository.Add(invoice);
    
        foreach (var product in command.Products)
        {
            var invoiceProduct = InvoiceProduct.Add(invoiceId, product.ProductId, product.Quantity);
            _invoiceProductDomainRepository.Add(invoiceProduct);
        }
        _logger.LogInformation("Счет {0} - с ID = {1} успешно создан", command.Number, invoiceId);
        return ValueTask.FromResult(invoiceId);
    }
}

public record AddInvoiceCommand : ICommand<Guid>
{
    public string Number { get; set; } = default!;
    public Guid ContractorId { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset PaymentDeadline { get; set; }
    public Priority Priority { get; set; } = null!;
    public PaymentStatus PaymentStatus { get; set; } = null!;
    public DateTimeOffset CreateDate { get; set; }
    public decimal? PaymentPercentage { get; set; }
    public IReadOnlyCollection<InvoiceProductCreate> Products { get; set; } =
        ReadOnlyCollection<InvoiceProductCreate>.Empty;
}

public class InvoiceProductCreate
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}