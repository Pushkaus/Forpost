using Forpost.Store.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Store.Repositories.Abstract.Repositories;

public interface IInvoiceRepository
{
    public Task<IActionResult> CreateInvoice(Guid userId, string number, string contragent, string comment,
        CancellationToken cancellationToken);
    public Task<List<Invoice>> GetInvoice(string invoiceNumber, CancellationToken cancellationToken);
    public Task<IActionResult> UpdateInvoice(Invoice invoice);
    public Task<IActionResult> DeleteInvoice(int invoiceId);
    
}