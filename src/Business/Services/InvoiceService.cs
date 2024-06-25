using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Services;

public class InvoiceService: IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;

    public InvoiceService(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }
    public async Task<List<Invoice>> GetInvoice(string invoiceNumber, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceRepository.GetInvoice(invoiceNumber, cancellationToken);
        return invoices;
    }

    public async Task<IActionResult> CreateInvoice(Guid userId, string number, string contragent, string comment,
        CancellationToken cancellationToken)
    {
        var result = await _invoiceRepository.CreateInvoice(userId, number, contragent, comment, cancellationToken);
        return new OkResult(); // Возвращаем успешный результат
    }
}