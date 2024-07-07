using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceService
{
    public Task<Invoice?> GetByNumber(string number);
    public Task<IReadOnlyList<Invoice>> GetAll();
    public Task Create(InvoiceCreateModel model);
    public Task Update(InvoiceUpdateModel model);
    public Task DeleteById(Guid id);
}