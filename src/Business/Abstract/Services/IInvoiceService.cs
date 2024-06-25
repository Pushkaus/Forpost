using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceService
{
    public Task<List<Invoice>> GetInvoice(string invoiceNumber, CancellationToken cancellationToken);
    public Task<IActionResult> CreateInvoice(Guid userId, string number, string contragent, string comment,
        CancellationToken cancellationToken);
}