using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Files;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Forpost.Business.Services;

public class InvoiceModel
{
    public string Name { get; set; } = null!;
}
internal sealed class InvoiceService: IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;


    public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
    }
    public async Task<Invoice?> GetByNumber(string number)
    {
        var invoice = await _invoiceRepository.GetByNumberAsync(number);
        return invoice;
    }

    public async Task<IReadOnlyList<Invoice>> GetAll()
    {
        var invoices = await _invoiceRepository.GetAllAsync();
        return invoices;
    }

    public async Task Expose(InvoiceCreateModel model)
    {
        var invoice = _mapper.Map<Invoice>(model);
        await _invoiceRepository.AddAsync(invoice);
    }

    public async Task Closing(InvoiceUpdateModel model)
    {
        model.Status = Status.Completed;
        model.DateShipment = DateTimeOffset.UtcNow;
        var invoice = _mapper.Map<Invoice>(model);
        await _invoiceRepository.UpdateAsync(invoice);
    }

    public async Task Update(InvoiceUpdateModel model)
    {
        var invoice = _mapper.Map<Invoice>(model);
        await _invoiceRepository.UpdateAsync(invoice);
    }

    public async Task DeleteById(Guid id)
    {
        await _invoiceRepository.DeleteByIdAsync(id);
    }
    
}