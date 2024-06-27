using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Web.Contracts;
[ApiController]
[Route("api/v1/invoices")]

public class InvoiceController: ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }
    /// <summary>
    /// Получить счет по его номеру
    /// </summary>
    [HttpGet("get-invoice")]
    public async Task<List<Invoice>> GetInvoice(string invoiceNumber, CancellationToken cancellationToken)
    {
        var invoices = await _invoiceService.GetInvoice(invoiceNumber, cancellationToken);
        return invoices;
    }

    /// <summary>
    /// Добавить счет
    /// </summary>
    [HttpPut("add-invoice")]
    public async Task<IActionResult> CreateInvoice(Guid userId, string number, string contragent, string comment,
        CancellationToken cancellationToken)
    {
        var result = await _invoiceService.CreateInvoice(userId, number, contragent, comment, cancellationToken);
        return result;
    }
}