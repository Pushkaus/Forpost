using Forpost.Business.Models.Files;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forpost.Business.Abstract.Services;

public interface IInvoiceService: IBusinessService
{
    public Task<Invoice?> GetByNumber(string number);
    public Task<IReadOnlyList<Invoice>> GetAll();
    public Task Expose(InvoiceCreateModel model);
    public Task Update(InvoiceUpdateModel model);
    public Task DeleteById(Guid id);
    
}