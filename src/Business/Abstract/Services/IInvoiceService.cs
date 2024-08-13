using Forpost.Business.Models.Files;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceService: IBusinessService
{
    public Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken);
    public Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken);
    public Task<Guid> ExposeAsync(InvoiceCreateModel model, CancellationToken cancellationToken);
    public Task ClosingAsync(InvoiceUpdateModel model, CancellationToken cancellationToken);
    public Task UpdateAsync(InvoiceUpdateModel model, CancellationToken cancellationToken);
    public Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    
}