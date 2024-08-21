using AutoMapper;
using Forpost.Business.Abstract.Services;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract.Repositories;

namespace Forpost.Business.Services;

public class InvoiceModel
{
    public string Name { get; set; } = null!;
}

internal sealed class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IMapper _mapper;
    private readonly TimeProvider _timeProvider;


    public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, TimeProvider timeProvider)
    {
        _invoiceRepository = invoiceRepository;
        _mapper = mapper;
        _timeProvider = timeProvider;
    }

    public async Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceRepository.GetByNumberAsync(number, cancellationToken);
        return invoice;
    }

    public async Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken)
    {
        var invoices = await _invoiceRepository.GetAllAsync(cancellationToken);
        return invoices;
    }

    public async Task<Guid> ExposeAsync(InvoiceCreateModel model, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<Invoice>(model);
        invoice.IssueStatus = IssueStatus.Pending; // Заводя счет, выставляется статус - ожидаемый
        return await _invoiceRepository.AddAsync(invoice, cancellationToken);
    }

    public async Task CloseAsync(InvoiceUpdateModel model, CancellationToken cancellationToken)
    {
        model.IssueStatus = IssueStatus.Completed;
        model.DateShipment = _timeProvider.GetUtcNow();
        var invoice = _mapper.Map<Invoice>(model);
        await _invoiceRepository.UpdateAsync(invoice, cancellationToken);
    }

    public async Task UpdateAsync(InvoiceUpdateModel model, CancellationToken cancellationToken)
    {
        var invoice = _mapper.Map<Invoice>(model);
        await _invoiceRepository.UpdateAsync(invoice, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        await _invoiceRepository.DeleteByIdAsync(id, cancellationToken);
    }
}