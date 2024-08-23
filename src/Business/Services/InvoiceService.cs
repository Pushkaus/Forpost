using AutoMapper;
using Forpost.Business.Abstract;
using Forpost.Business.Abstract.Services;
using Forpost.Business.EventHanding;
using Forpost.Business.Models.Invoices;
using Forpost.Store.Entities;
using Forpost.Store.Enums;
using Forpost.Store.Repositories.Abstract;
using Forpost.Store.Repositories.Abstract.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Forpost.Business.Services;

public class InvoiceModel
{
    public string Name { get; set; } = null!;
}

internal sealed class InvoiceService : BaseBusinessService, IInvoiceService
{
    public InvoiceService(
        IDbUnitOfWork dbUnitOfWork,
        ILogger<BaseBusinessService> logger,
        IMapper mapper,
        IConfiguration configuration,
        TimeProvider timeProvider
    )
        : base(dbUnitOfWork, logger, mapper, configuration, timeProvider)
    {
    }

    public async Task<Invoice?> GetByNumberAsync(string number, CancellationToken cancellationToken)
    {
        var invoice = await DbUnitOfWork.InvoiceRepository.GetByNumberAsync(number, cancellationToken);
        return invoice;
    }

    public async Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken cancellationToken)
    {
        var invoices = await DbUnitOfWork.InvoiceRepository.GetAllAsync(cancellationToken);
        return invoices;
    }

    public async Task<Guid> ExposeAsync(InvoiceCreateModel model, CancellationToken cancellationToken)
    {
        var invoice = Mapper.Map<Invoice>(model);
        invoice.IssueStatus = IssueStatus.Pending; // Заводя счет, выставляется статус - ожидаемый
        DbUnitOfWork.InvoiceRepository.Add(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
        
        return Guid.Empty;
    }

    public async Task CloseAsync(InvoiceUpdateModel model, CancellationToken cancellationToken)
    {
        model.IssueStatus = IssueStatus.Completed;
        model.DateShipment = TimeProvider.GetUtcNow();
        var invoice = Mapper.Map<Invoice>(model);
        DbUnitOfWork.InvoiceRepository.Update(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(InvoiceUpdateModel model, CancellationToken cancellationToken)
    {
        var invoice = Mapper.Map<Invoice>(model);
        DbUnitOfWork.InvoiceRepository.Update(invoice);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        DbUnitOfWork.InvoiceRepository.DeleteById(id);
        await DbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}